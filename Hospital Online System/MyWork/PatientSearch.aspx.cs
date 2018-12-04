using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Media;

public partial class MyWork_PatientSearch : System.Web.UI.Page
{
    TGDBEntities dbcon = new TGDBEntities();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = string.Empty;
        Label1.Visible = false;
        Label2.Visible = false;
        try
        {
            PatientTable abc = (from x in dbcon.PatientTables
                                where x.PatientUserName == TextBox1.Text.Trim()
                                select x).First();
            Label1.Text = (abc.Name + "; " + abc.Address + "; " + abc.Email + "; " + abc.Phone);
            Label1.Visible = true;
        }
        catch (System.InvalidOperationException)
        {
            Label2.Visible = true;
        }

        
    }
}