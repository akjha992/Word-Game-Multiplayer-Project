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
        Boolean[] sub_answers = new Boolean[nop];
        for (int i = 0; i < nop; i++)
        {
            sub_answers[i] = false;
        }
        Application[code.ToString() + "sub_answers"] = sub_answers;
        //****************************************

        //no of players submitted their answer
        int psa = 0;
        Application[code.ToString() + "psa"] = psa;
        //**************************************

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
        Session["updated"] = false;//for point updation
        wait.InnerText = "Waiting for other players ...";
        int code = Convert.ToInt32(Session["code"]);
        int pso = (int)Application[code.ToString() + "pso"];
        Boolean[] sub_options = (Boolean[])Application[code.ToString() + "sub_options"];
        String[] pnames = (String[])Application[code.ToString() + "pnames"];
        int nop = (int)Application[code.ToString() + "nop"];
        if (pso == nop)
        {

            Response.Redirect("answersubmission.aspx");
        }
        else
        {
            update(pnames, sub_options, PlaceHolder1);
        }
        
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
        
    }
}