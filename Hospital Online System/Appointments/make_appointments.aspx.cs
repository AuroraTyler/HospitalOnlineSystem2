using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class Appointments_make_appointments : System.Web.UI.Page
{
    TGDBEntities dbcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/MyWork/Home.aspx");
        }
        if (!IsPostBack)
        {
            dbcon = new TGDBEntities();
        }
    }

    protected void makeAppointmentButton_Click(object sender, EventArgs e)
    {
        int userID = 0;
        TGDBEntities dbconP = new TGDBEntities();
        var patUser = (from x in dbconP.PatientTables
                       where x.PatientUserName == User.Identity.Name
                       select x).First();
        userID = patUser.PatientId;

        //enter selections into variables
        DateTime newAppDate = Convert.ToDateTime(dateSelectionCalendar.SelectedDate);
        TimeSpan newAppTime = new TimeSpan(Convert.ToInt32(hourDropDownList.SelectedValue), Convert.ToInt32(minuteDropDownList.SelectedValue), 0);
        string newAppReason = reasonTextBox.Text;
        string newAppDoctorName = doctorDropDownList.SelectedItem.Value;
        TGDBEntities dbconD = new TGDBEntities();
        var newAppDoc = (from x in dbconD.DoctorTables
                         where x.Name == newAppDoctorName
                         select x).First();
        int newAppDoctor = newAppDoc.DoctorId;


        //verify input and create new Appointment
        //verify date is in the future
        if (newAppDate <= DateTime.Today)
        {
            confirmationLabel.Text = "Please schedule your appointment for a future date.";
        }

        else
        {
            //date and time is free for patient and doctor


            TGDBEntities dbconA = new TGDBEntities();
            var existApp = (from x in dbconA.AppointmentTables
                            where x.AppointmentDate == newAppDate
                            select x).FirstOrDefault();


            TGDBEntities dbconA2 = new TGDBEntities();
            var existAppDoc = (from x in dbconA2.AppointmentTables
                               where x.DoctorId == newAppDoctor
                               select x).FirstOrDefault();

            if (existApp != null) //there is already an appointment on the selected date
            {
                if (existApp.PatientId == userID) //the appointment belongs to the patient/user
                {
                    if (existApp.AppointmentTime == newAppTime) //the appointment is for the same time
                    {
                        confirmationLabel.Text = "You already have an appointment for that day and time, please select another day or time to make your appointment.";
                    }
                }

                if (existAppDoc != null) //the appointment belongs to the selected doctor
                {
                    if (existAppDoc.AppointmentTime == newAppTime) //appointment is for the same time
                    {
                        confirmationLabel2.Text = "The selected doctor already has an appointment for that day and time, please select another day or time, or a different doctor to make your appointment.";
                    }
                }
            }
            else //there is not an existing appointment for the selected date, so create appointment
            {

                AppointmentTable newAppointment = new AppointmentTable();
                //add data to newAppointment
                newAppointment.AppointmentDate = newAppDate;
                newAppointment.AppointmentTime = newAppTime;
                newAppointment.Description = newAppReason;
                newAppointment.DoctorId = newAppDoctor;
                newAppointment.PatientId = userID;

                //add newAppointment to the Table
                dbcon = new TGDBEntities();
                dbcon.AppointmentTables.Add(newAppointment);
                dbcon.SaveChanges();

                //clear form
                dateSelectionCalendar.SelectedDates.Clear();
                hourDropDownList.SelectedIndex = -1;
                minuteDropDownList.SelectedIndex = -1;
                hospitalDropDownList.SelectedIndex = -1;
                departmentDropDownList.Items.Clear();
                doctorDropDownList.Items.Clear();
                reasonTextBox.Text = "";

                //confirm appointment
                confirmationLabel.Text = "Appointment was successfully created!";
                confirmationLabel2.Text = "We will see you on " + newAppDate.ToShortDateString() + " at " + newAppTime + " for your appointment with " + newAppDoctorName + " for " + newAppReason;
            }
        }
    }

    protected void hospitalDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedHospital = Convert.ToInt32(hospitalDropDownList.SelectedItem.Value);

        TGDBEntities dbconH = new TGDBEntities();
        dbconH.DepartmentTables.Load();
        var dept = from x in dbconH.DepartmentTables.Local
                   where x.HospitalId == selectedHospital
                   select x.Specialization;

        departmentDropDownList.DataSource = dept.ToList();
        departmentDropDownList.DataBind();
    }

    protected void departmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedDepartment = departmentDropDownList.SelectedItem.Value;

        TGDBEntities dbconH = new TGDBEntities();
        dbconH.DepartmentTables.Load();

        var deptId = (from x in dbconH.DepartmentTables
                     where x.Specialization == selectedDepartment
                     select x.DepartmentId).First();

        TGDBEntities dbconD = new TGDBEntities();
        dbconD.DoctorTables.Load();
        var doc = from x in dbconD.DoctorTables.Local
                  where x.DepartmentId == deptId
                  select x.Name;

        doctorDropDownList.DataSource = doc.ToList();
        doctorDropDownList.DataBind();

    }
}