using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class Appointments_view_appointments : System.Web.UI.Page
{
    TGDBEntities dbcon = new TGDBEntities();
    int userID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/MyWork/Home.aspx");
        }

        

        TGDBEntities dbconP = new TGDBEntities();

        var patUser = (from x in dbconP.PatientTables
                       where x.PatientUserName == User.Identity.Name
                       select x).First();

        userID = patUser.PatientId;
        RefreshGridView();
    }

    protected void RefreshGridView()
    {
        if (dbcon != null)
            dbcon.Dispose();
        

        dbcon = new TGDBEntities();
        dbcon.AppointmentTables.Where(item => item.PatientId.Equals(userID)).Load();

        UpcomingAppointmentsGridView.DataSource = dbcon.AppointmentTables.Local;
        UpcomingAppointmentsGridView.DataBind();
    }

    protected void UpcomingAppointmentsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        TGDBEntities dbconA = new TGDBEntities();
        TGDBEntities dbconD = new TGDBEntities();

        int selectedAppointment = (int)UpcomingAppointmentsGridView.SelectedDataKey[0];

        var selectedApt = (from x in dbconA.AppointmentTables
                           where x.AppointmentId == selectedAppointment
                           select x).First();

        var aptDoc = (from x in dbconD.DoctorTables
                     where x.DoctorId == selectedApt.DoctorId
                     select x).First();

        string aptDescription = selectedApt.Description;
        string aptDate = selectedApt.AppointmentDate.ToShortDateString();
        string aptTime = selectedApt.AppointmentTime.ToString();
        string aptDoctorName = aptDoc.Name;

        selectedAppointmentLabel.Text = "You have an appointment on " + aptDate + " at " + aptTime + " with " + aptDoctorName + " for the following reason: " + aptDescription;
    }

    protected void deleteAppointmentButton_Click(object sender, EventArgs e)
    {
        dbcon = new TGDBEntities();
        dbcon.AppointmentTables.Load();
        int selectedAppointment = (int)UpcomingAppointmentsGridView.SelectedDataKey[0];

        

        var selectedApt = (from x in dbcon.AppointmentTables
                           where x.AppointmentId == selectedAppointment
                           select x).First();

        if (selectedApt != null)
        {
            dbcon.AppointmentTables.Remove(selectedApt);
            dbcon.SaveChanges();
        }

        RefreshGridView();
    }



    
}