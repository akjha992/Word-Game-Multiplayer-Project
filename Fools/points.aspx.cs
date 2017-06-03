using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class points : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int code = Convert.ToInt32(Session["code"]);
        int rcount = (int)Application[code.ToString() + "rcount"];
        String[] pnames = (String[])Application[code.ToString() + "pnames"];
        int[] points = (int[])Application[code.ToString() + "points"];
        int nop = (int)Application[code.ToString() + "nop"];
        Boolean correct= (Boolean)Session["correct"];
        if (!IsPostBack)
        {
            
        }
        //if (!IsPostBack)
        //{

        //   if(!(Boolean)Session["updated"])
        //    {
        //        Session["updated"] = true;
        //        if (Session["admin"] != null)
        //        {

        //            //rcount++;
        //            //Application["rcount"] = rcount;
        //        }

        //        if (psycher == nop)
        //        {
        //            correct = true;
        //            points[pindex] += 2;
        //            Application[code.ToString() + "points"] = points;
        //        }
        //        else
        //        {
        //            points[psycher] += 5;
        //            Application[code.ToString() + "points"] = points;
        //            correct = false;
        //        }
        //    }

        //}
        Label2.Text = "Round - " + (rcount) + "/10";
        for (int i=0;i< nop;i++)
        {
            PlaceHolder1.Controls.Add(new LiteralControl(pnames[i] + "&nbsp" + points[i]+ "<br />"));
        }
        if(rcount==10)
        {
            Button1.Text = "Play again";
        }
        if(correct)
        {
            gotpsyched.InnerText = "Congrats! Your Answer Was Correct!";
        }
        else
        {
            gotpsyched.InnerText = "Oops! Your Answer Was wrong!";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int code = Convert.ToInt32(Session["code"]);
        if(((Button)sender).Text=="Play again")
        {
            Response.Redirect("gamestarter.aspx");
        }
        else
        {
            Boolean[] sub_newround = (Boolean[])Application[code.ToString() + "sub_newround"];
            int nr = (int)Application[code.ToString() + "nr"];
            int pindex = (int)Session["pindex"];
            
            sub_newround[pindex] = true;
            Application[code.ToString() + "sub_answers"] = sub_newround;
            
            nr++;
            Application[code.ToString() + "nr"] = nr;
            
            Response.Redirect("waiting3.aspx");
        }
    }
}