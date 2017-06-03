using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    public void create_Variables()
    {
        //get code,admin_status ,player_index and nop
        int code = Convert.ToInt32(Session["code"]);
        Boolean admin = (Boolean)Session["admin"];
        int nop = Convert.ToInt32(Application[code.ToString() + "nop"]);
        //**************************************

        //create options array and submitted array
        String[] options = new string[nop];
        Application[code.ToString() + "options"] = options;
        Boolean[] sub_options = new Boolean[nop];
        for (int i = 0; i < nop; i++)
        {
            sub_options[i] = false;
        }
        Application[code.ToString() + "sub_options"] = sub_options;
        //****************************************

        //no of players submitted their options
        int pso = 0;
        Application[code.ToString() + "pso"] = pso;
        //**************************************

        //increment round count
        int roundcount = 1;
        Application[code.ToString() + "rcount"] = roundcount;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["player_name"] != null)
        {
            username.Text = "Welcome " + Session["player_name"].ToString();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    public void create()
    {
        int num = Convert.ToInt32(Session["code"]);
        int nop = (int)Application[num.ToString() + "nop"];
        String[] options = new string[nop];
        Boolean[] submitted = new Boolean[nop];
        Boolean[] submitted1 = new Boolean[nop];
        Boolean[] submitted2 = new Boolean[nop];
        for (int i = 0; i < nop; i++)
        {
            submitted[i] = false;
            submitted1[i] = false;
            submitted2[i] = false;
        }
        Application[num.ToString() + "phase"] = 1;
        Application[num.ToString() + "k"] = 0;
        Application[num.ToString() + "k1"] = 0;
        Application[num.ToString() + "options"] = options;
        Application[num.ToString() + "submitted"] = submitted;
        Application[num.ToString() + "submitted1"] = submitted1;
        Application[num.ToString() + "submitted2"] = submitted2;
        Application[num.ToString() + "k2"] = 0;
        Application["qnofetched"] = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //generate random code for admin
        Random r = new Random();
        int num = r.Next(1000, 9999);
        Session["code"] = num;
        //*****************************

        //update no of players and players_names and player id
        int nop= Convert.ToInt32(DropDownList1.SelectedItem.ToString());
        Application[num.ToString() + "nop"] = nop;
        Application[num.ToString() + "nop"] = nop;

        String[] pnames = new string[nop];
        pnames[0] = Session["player_name"].ToString();
        Application[num.ToString() + "pnames"] = pnames;

        int[] playerid = new int[nop];
        playerid[0] = Convert.ToInt32(Session["player_id"]);
        Application[num.ToString() + "player_id_array"] = playerid;
        //******************************

        //update playerjoined (pj), playerindex(pindex), roundcount(rcount), points
        Application[num.ToString() + "pj"] = "1";

        Session["pindex"] = 0;

        int roundcount = 0;
        Application[num.ToString() + "rcount"] = roundcount;

        int[] points = new int[nop];
        points[0] = 0;
        Application[num.ToString() + "points"] = points;
        //***********************************************************************

        Session["admin"] = true;

        Application["updated"] = false;//to check if admin only opoperations are updated

        Application["qnofetched"] = false;

        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strcon))
        {
            SqlCommand com = new SqlCommand("newgame", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@gamecode", num);
            com.Parameters.AddWithValue("@nop", nop);
            con.Open();
            com.ExecuteNonQuery();
        }
        create_Variables();
        Response.Redirect("create.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        int code = Convert.ToInt32(TextBox1.Text);
        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strcon))
        {
            SqlCommand com = new SqlCommand("select * from game where gamecode = @code", con);
            com.Parameters.AddWithValue("@code", TextBox1.Text);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            if(rdr.Read())
            {
                int nop = Convert.ToInt32(Application[code.ToString() + "nop"]);
                int pj = Convert.ToInt32(Application[code.ToString() + "pj"]);
                if(pj<nop)
                {
                    //setting session variables
                    Session["admin"] = false;
                    Session["code"] = code;
                    Session["pindex"] = pj;
                    //*************************

                    //updating player_joined(pj) and pnames,points and player_id
                    Application[code.ToString() + "pj"] = pj + 1;

                    String[] pnames = (String[])Application[code.ToString() + "pnames"];
                    pnames[pj] = Session["player_name"].ToString();
                    Application[code.ToString() + "pnames"] = pnames;

                    int[] playerid = (int[])Application[code.ToString() + "player_id_array"];
                    playerid[pj] = Convert.ToInt32(Session["player_id"]);
                    Application[code.ToString() + "player_id_array"] = playerid;

                    int[] points = (int[])Application[code.ToString() + "points"];
                    points[pj] = 0;
                    Application[code.ToString() + "points"] = points;
                    //***********************************************************
                    
                    Response.Redirect("create.aspx");
                }
            }

        }
        

    }
}