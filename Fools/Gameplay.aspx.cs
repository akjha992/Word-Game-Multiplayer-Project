using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Gameplay : System.Web.UI.Page
{
    public void reset()
    {
        int num = Convert.ToInt32(Session["code"]);
        int nop = (int)Application[num.ToString() + "nop"];
        String[] options = new string[nop];
        Boolean[] submitted = new Boolean[nop];
        Boolean[] submitted1 = new Boolean[nop];
        for(int i=0;i< nop;i++)
        {
            submitted[i] = false;
            submitted1[i] = false;
        }
        
        Application[num.ToString() + "k"] = 0;
        Application[num.ToString() + "k1"] = 0;
        Application[num.ToString() + "options"] = options;
        Application[num.ToString() + "submitted"] = submitted;
        Application[num.ToString() + "submitted1"] = submitted1;
        
        int rcount = (int)(Application[num.ToString() + "rcount"]);
        rcount++;

        Application[num.ToString() + "rcount"] = rcount;
        Session["updated"] = false;
        Application["qnofetched"] = false;
    }
    public void updatequestion(int qno)
    {
        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strcon))
        {

            SqlCommand com = new SqlCommand("select question,answer from qbank where qno=@qno", con);
            com.Parameters.AddWithValue("@qno", qno);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            String question = (dt.Rows[0][0].ToString());
            String answer = (dt.Rows[0][1].ToString());
            Session["currentanswer"] = answer;
            question_label.InnerText = question;
        }
    }
    public int get_questoin_no()
    {
        //get code,admin_status and player_index
        int code = Convert.ToInt32(Session["code"]);
        Boolean admin = (Boolean)Session["admin"];
        int pj = Convert.ToInt32(Application[code.ToString() + "pj"]);
        int[] playerid = (int[])Application[code.ToString() + "player_id_array"];
        //**************************************
        int qno = 0;
        if (!(Boolean)Application["qnofetched"])
        {
            if ((Boolean)Session["admin"])
            {
                //fetch
                string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;
                DataTable t = new DataTable();
                t.Columns.Add("id");
                for (int i = 0; i < playerid.Length; i++)
                {
                    t.Rows.Add(playerid[i]);
                }
                using (SqlConnection con = new SqlConnection(strcon))
                {

                    SqlCommand com = new SqlCommand("getmax", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@idtable1", t);
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    qno = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Application[code.ToString() + "questionno"] = qno;
                    
                    Application["qnofetched"] = true;
                }
            }
            else
            {
                while (!(Boolean)Application["qnofetched"])
                {

                }
                qno = Convert.ToInt32(Application[code.ToString() + "questionno"]);
            }
        }
        else
        {
            qno= Convert.ToInt32(Application[code.ToString() + "questionno"]);
        }
        return qno;
    }
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
        int roundcount = Convert.ToInt32(Application[code.ToString() + "rcount"])+1;
        Application[code.ToString() + "rcount"] = roundcount;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //get code,admin_status and player_index
        int code = Convert.ToInt32(Session["code"]);
        Boolean admin = (Boolean)Session["admin"];
        int pj = Convert.ToInt32(Application[code.ToString() + "pj"]);
        //**************************************

        updatequestion(get_questoin_no());
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Visible = false;

        int code = Convert.ToInt32(Session["code"]);
        int pindex = (int)Session["pindex"];

        //update options and submitted
        String[] options = (String[])Application[code.ToString() + "options"];
        options[pindex] = TextBox1.Text.ToLower();
        Application[code.ToString() + "options"] = options;

        Boolean[] sub_options = (Boolean[])Application[code.ToString() + "sub_options"];
        sub_options[pindex] = true;
        Application[code.ToString() + "sub_options"] = sub_options;
        //***************************

        int pso = (int)Application[code.ToString() + "pso"];
        pso++;
        Application[code.ToString() + "pso"] = pso;
        Response.Redirect("waiting1.aspx");
    }
}