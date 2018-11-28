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
            loadDoc();
        }
    }
        HOSEntities dbcon = new HOSEntities();

    protected void Button1_Click(object sender, EventArgs e)
    {


        EmailTable email = new EmailTable();

        //add data to email
        email.SenderUserName = User.Identity.Name;
        email.RecipientUserName = DropDownList1.SelectedItem.Text;
        email.EmailText = TextBox2.Text;
        email.EmailDate = System.DateTime.SpecifyKind(System.DateTime.Now, DateTimeKind.Local);

        //add email to table
        dbcon.EmailTables.Add(email);
        dbcon.SaveChanges();

        //clear text boxes
        TextBox2.Text = string.Empty;

        

        Response.Redirect("MessagesMain.aspx");
       
    }

    public void loadDoc()
    {
        var patUser = (from x in dbcon.PatientTables
                       where x.PatientUserName == User.Identity.Name
                       select x).First();

        int userDocId = Convert.ToInt32(patUser.DoctorId);

        var userDoc = (from x in dbcon.DoctorTables
                       where x.DoctorId == userDocId
                       select x).First();
        DropDownList1.Items.Add(userDoc.DoctorUserName);
        
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}