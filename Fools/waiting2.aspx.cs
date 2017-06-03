using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class waiting : System.Web.UI.Page
{


    public void create_Variables()
    {
        //get code,admin_status ,player_index and nop
        int code = Convert.ToInt32(Session["code"]);
        Boolean admin = (Boolean)Session["admin"];
        int nop = Convert.ToInt32(Application[code.ToString() + "nop"]);
        //**************************************

        //create answer submitted array
        Boolean[] sub_newround = new Boolean[nop];
        for (int i = 0; i < nop; i++)
        {
            sub_newround[i] = false;
        }
        Application[code.ToString() + "sub_newround"] = sub_newround;
        //****************************************

        //no of players went for new round(nr)
        int nr = 0;
        Application[code.ToString() + "nr"] = nr;
        //**************************************
        Application["qnofetched"] = false;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Boolean)Session["admin"])
            {
                create_Variables();
            }
        }
        wait.InnerText = "Waiting for other players ...";
        int code = Convert.ToInt32(Session["code"]);
        int psa = (int)Application[code.ToString() + "psa"];
        Boolean[] sub_answers = (Boolean[])Application[code.ToString() + "sub_answers"];
        String[] pnames = (String[])Application[code.ToString() + "pnames"];
        int nop = (int)Application[code.ToString() + "nop"];
        if (psa == nop)
        {

            Response.Redirect("points.aspx");
        }
        else
        {
            update(pnames, sub_answers, PlaceHolder1);
        }
        
    }


    public void update(String[] pnames, Boolean[] submitted, PlaceHolder p)
    {
        for (int i = 0; i < pnames.Length; i++)
        {
            if (!submitted[i])
            {
                p.Controls.Add(new LiteralControl(pnames[i] + "<br />"));
            }
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {

    }
}