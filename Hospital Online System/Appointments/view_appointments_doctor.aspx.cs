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

        RefreshGridView();
        
    }

    protected void RefreshGridView()
    {
        if (dbcon != null)
            dbcon.Dispose();
        TGDBEntities dbconD = new TGDBEntities();

        var docUser = (from x in dbconD.DoctorTables
                       where x.DoctorUserName == User.Identity.Name
                       select x).First();

        userID = docUser.DoctorId;

        TGDBEntities dbconA = new TGDBEntities();
        dbconA.AppointmentTables.Where(item => item.DoctorId.Equals(userID)).Load();

        UpcomingAppointmentsGridView.DataSource = dbconA.AppointmentTables.Local;
        UpcomingAppointmentsGridView.DataBind();
    }

    protected void UpcomingAppointmentsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        TGDBEntities dbconA = new TGDBEntities();
        TGDBEntities dbconP = new TGDBEntities();

        int selectedAppointment = (int)UpcomingAppointmentsGridView.SelectedDataKey[0];

        var selectedApt = (from x in dbconA.AppointmentTables
                           where x.AppointmentId == selectedAppointment
                           select x).First();
        var aptPat = (from x in dbconP.PatientTables
                     where x.PatientId == selectedApt.PatientId
                     select x).First();

        string aptDescription = selectedApt.Description;
        string aptDate = selectedApt.AppointmentDate.ToShortDateString();
        string aptTime = selectedApt.AppointmentTime.ToString();
        string aptPatientName = aptPat.Name;

        selectedAppointmentLabel.Text = "You have an appointment on \n" + aptDate + "\n at " + aptTime + "\n with " + aptPatientName + "\n for the following reason: " + aptDescription;
    }
    
}