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
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            
        }
    }


    protected void login_Click(object sender, EventArgs e)
    {
        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;
        string user_id = id.Text;
        string user_pass = pass.Text;
        String dispname="";
        using (SqlConnection con = new SqlConnection(strcon))
        {

            SqlCommand com = new SqlCommand("select name,id from players where username='" + user_id + "' and pass='" + user_pass + "'", con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            if (dt.Rows.Count == 1)
            {
                dispname = dt.Rows[0][0].ToString();
                Session["player_name"] = dispname;
                Session["player_id"] = Convert.ToInt32(dt.Rows[0][1].ToString()) ;
                Response.Redirect("gamestarter.aspx");
            }
            else
            {
                error.InnerText = "Wrong Username or Password";
            }
        }
    }

    protected void signup_Click(object sender, EventArgs e)
    {

    }
}