using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

public partial class create : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int code, nop;
        code = Convert.ToInt32(Session["code"]);
        if (!IsPostBack)
        {
            Label1.Text = code + "";     
        }
        nop = Convert.ToInt32(Application[code.ToString() + "nop"]);
        int pj = Convert.ToInt32(Application[code.ToString() + "pj"]);
        String[] pnames = (String[])Application[code.ToString() + "pnames"];
        Label2.Text = "Players Joined - "+pj + "/" + nop;
        for(int i=0;i<pj;i++)
        {
            PlaceHolder1.Controls.Add(new LiteralControl(pnames[i]));
            PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
        }
        if (pj == nop)
        {
            Response.Redirect("Gameplay.aspx");
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {

    }
}