using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class waiting : System.Web.UI.Page
{
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        wait.InnerText = "Waiting for other players ...";
    }


    public void update(String[] pnames,Boolean[] submitted,PlaceHolder p)
    {
        for(int i=0;i<pnames.Length;i++)
        {
            if(!submitted[i])
            {
                p.Controls.Add(new LiteralControl(pnames[i] + "<br />"));
            }
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        int code = Convert.ToInt32(Session["code"]);
        int k = (int)Application[code.ToString() + "k"];
        int k1 = (int)Application[code.ToString() + "k1"];
        int k2 = (int)Application[code.ToString() + "k2"];
        Boolean[] submitted = (Boolean[])Application[code.ToString() + "submitted"];
        Boolean[] submitted1 = (Boolean[])Application[code.ToString() + "submitted1"];
        Boolean[] submitted2 = (Boolean[])Application[code.ToString() + "submitted2"];
        String[] pnames = (String[])Application[code.ToString() + "pnames"];
        int nop = (int)Application[code.ToString() + "nop"];
        if ((int)Application[code.ToString() + "phase"] == 2)
        {
            if (k1 == nop)
            {

                Response.Redirect("points.aspx");
            }
            else
            {
                update(pnames, submitted1, PlaceHolder1);
            }
        }
        else if (((int)Application[code.ToString() + "phase"] == 1))
        {
            if (k == nop)
            {

                Response.Redirect("answersubmission.aspx");
            }
            else
            {
                update(pnames, submitted, PlaceHolder1);
            }
        }
        else
        {
            if (k2 == nop)
            {

                Response.Redirect("Gameplay.aspx");
            }
            else
            {
                update(pnames, submitted2, PlaceHolder1);
            }

        }
    }
}