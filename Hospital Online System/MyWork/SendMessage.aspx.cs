using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_Online_System;
using System.Data.Entity;

public partial class MyWork_SendMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadPat();
        }
    }

    public void loadPat()
    {
        var patUser = (from x in dbcon.DoctorTables
                       where x.DoctorUserName == User.Identity.Name
                       select x).First();

        int userDocId = Convert.ToInt32(patUser.DoctorId);

        var userPat = from x in dbcon.PatientTables
                       where x.DoctorId == userDocId
                       select x;
        //DropDownList1.Items.Add(userPat.ToString());
        foreach(PatientTable x in userPat)
        {
            DropDownList1.Items.Add(x.PatientUserName);
        }


    }
        TGDBEntities dbcon = new TGDBEntities();

    protected void Button1_Click(object sender, EventArgs e)
    {

        EmailTable email = new EmailTable();

        //add data to email
        email.SenderUserName = User.Identity.Name;
        email.RecipientUserName = DropDownList1.SelectedItem.Value;
        email.EmailText = TextBox2.Text;
        email.EmailDate = System.DateTime.SpecifyKind(System.DateTime.Now, DateTimeKind.Local);

        //add email to table
        dbcon.EmailTables.Add(email);
        dbcon.SaveChanges();

        //clear text boxes
        TextBox2.Text = string.Empty;

        

        Response.Redirect("MessagesMain.aspx");
       
    }
}