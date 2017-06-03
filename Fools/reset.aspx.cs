using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reset : System.Web.UI.Page
{
    public void doreset()
    {
        int code = Convert.ToInt32(Session["code"]);
        int nop = (int)Application[code.ToString() + "nop"];
        int k = (int)Application[code.ToString() + "k"];
        int k1 = (int)Application[code.ToString() + "k1"];
        int k2 = (int)Application[code.ToString() + "k2"];
        Boolean[] submitted = (Boolean[])Application[code.ToString() + "submitted"];
        Boolean[] submitted1 = (Boolean[])Application[code.ToString() + "submitted1"];
        Boolean[] submitted2 = (Boolean[])Application[code.ToString() + "submitted2"];
        Application[code.ToString() + "phase"] = 1;
        for (int i = 0; i < nop; i++)
        {
            submitted[i] = false;
            submitted1[i] = false;
            submitted2[i] = false;

        }
        k = 0;
        k1 = 0;
        k2 = 0;
        Application[code.ToString() + "phase"] = 1;
        Application[code.ToString() + "k"] = k;
        Application[code.ToString() + "k1"] = k1;
        Application[code.ToString() + "k2"] = k2;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        int code = Convert.ToInt32(Session["code"]);
        if (!IsPostBack)
        {
            if (!(Boolean)Application[code.ToString() + "reset"])
            {

                doreset();
                Application[code.ToString() + "reset"] = true;
                Response.Redirect("Gameplay.aspx");
            }
            
        }
    }
}