using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class answersubmission : System.Web.UI.Page
{
    public void reset()
    {
        int num = Convert.ToInt32(Session["code"]);
        int nop = (int)Application[num.ToString() + "nop"];
       
        Boolean[] submitted2 = new Boolean[nop];
        for (int i = 0; i < nop; i++)
        {
            submitted2[i] = false;
        }
        Application[num.ToString() + "submitted2"] = submitted2;
        Application[num.ToString() + "k2"] = 0;
        
        
    }
    public void shuffle(int[] array)
    {
        Random rand = new Random();
        int n = array.Count();
        while(n>1)
        {
            n--;
            int i = rand.Next(n + 1);
            int temp = array[i];
            array[i] = array[n];
            array[n] = temp;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        DataTable t = new DataTable();
        t.Columns.Add();
        int code = Convert.ToInt32(Session["code"]);
        
        
        int nop = (int)Application[code.ToString() + "nop"];
        String[] options = (String[])Application[code.ToString() + "options"];
        int pindex = Convert.ToInt32(Session["pindex"]);
        
        Random r = new Random();
        int[] randomize = new int[nop + 1];//correct answer index = nop
        for(int i=0;i<nop+1;i++)
        {
            randomize[i] = i;
        }
        shuffle(randomize);

        int correct = nop;
        for (int i=0;i<=nop;i++)
        {
            Button b = new Button();
            b.CssClass = "chosenButtonsubmission";
            if (randomize[i]==correct)
            {

                b.Text = Session["currentanswer"].ToString().ToLower();
                b.ID = randomize[i].ToString();
                b.Click += new EventHandler(this.b_Click);
            }
            else
            {
                b.Text = options[randomize[i]];
                b.ID = randomize[i].ToString();
                if (randomize[i]==pindex)
                {
                    b.Attributes.Add("OnClick", "return generror()");
                }
                else
                {
                    b.Click += new EventHandler(this.b_Click);
                }
            }
            PlaceHolder1.Controls.Add(b);
            PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
        }
    }
    protected void b_Click(Object sender, EventArgs e)
    {

        Button clicked = (Button)sender;
        String answer = clicked.Text;
        int psycher = Convert.ToInt32(clicked.ID);
        Session["psycher"] = psycher;
        int code = Convert.ToInt32(Session["code"]);
        int pindex = Convert.ToInt32(Session["pindex"]);
        
        //update  subanswers
        Boolean[] sub_answers = (Boolean[])Application[code.ToString() + "sub_answers"];
        sub_answers[pindex] = true;
        Application[code.ToString() + "sub_answers"] = sub_answers;
        //***************************

        int psa = (int)Application[code.ToString() + "psa"];
        psa++;
        Application[code.ToString() + "psa"] = psa;
       
        
        int nop = (int)Application[code.ToString() + "nop"];
        int[] points = (int[])Application[code.ToString() + "points"];
        Boolean correct = false;
        if (!(Boolean)Session["updated"])
        {
            Session["updated"] = true;
            if (psycher == nop)
            {
                correct = true;
                points[pindex] += 2;
                Application[code.ToString() + "points"] = points;
            }
            else
            {
                points[psycher] += 5;
                Application[code.ToString() + "points"] = points;
                correct = false;
            }
            
        }
        Session["correct"] = correct;
        Response.Redirect("waiting2.aspx");
    }
}