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
        int roundcount = Convert.ToInt32(Application[code.ToString() + "rcount"]) + 1;
        Application[code.ToString() + "rcount"] = roundcount;

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
        int nr = (int)Application[code.ToString() + "nr"];
        Boolean[] sub_newround = (Boolean[])Application[code.ToString() + "sub_newround"];
        String[] pnames = (String[])Application[code.ToString() + "pnames"];
        int nop = (int)Application[code.ToString() + "nop"];
        if (nr == nop)
        {

            Response.Redirect("Gameplay.aspx");
        }
        else
        {
            update(pnames, sub_newround, PlaceHolder1);
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