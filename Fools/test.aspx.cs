using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        if(question.Text!=""||answer.Text!="")
        {
            String qu = question.Text;
            String answ = answer.Text;
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {

                SqlCommand com = new SqlCommand("insert into qbank values(@ques,@ans)", con);
                com.Parameters.AddWithValue("@ques", qu);
                com.Parameters.AddWithValue("@ans", answ);
                con.Open();
                com.ExecuteNonQuery();

            }
            question.Text = "";
            answer.Text = "";
        }
    }
}