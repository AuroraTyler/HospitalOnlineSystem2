using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class Appointments_view_appointments : System.Web.UI.Page
{
    HOSEntities dbcon = new HOSEntities();
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
        HOSEntities dbconP = new HOSEntities();

        var patUser = (from x in dbconP.PatientTables
                       where x.PatientUserName == User.Identity.Name
                       select x).First();

        userID = patUser.PatientId;

        HOSEntities dbconA = new HOSEntities();
        dbconA.AppointmentTables.Where(item => item.PatientId.Equals(userID)).Load();

        UpcomingAppointmentsGridView.DataSource = dbconA.AppointmentTables.Local;
        UpcomingAppointmentsGridView.DataBind();
    }

    protected void UpcomingAppointmentsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        HOSEntities dbconA = new HOSEntities();
        HOSEntities dbconD = new HOSEntities();
        HOSEntities dbconH = new HOSEntities();
        HOSEntities dbconS = new HOSEntities();

        int selectedAppointment = (int)UpcomingAppointmentsGridView.SelectedDataKey[0];

        var apt = (from x in dbconA.AppointmentTables
                           where x.AppointmentId == selectedAppointment
                           select x).First();

        var aptDoc = (from x in dbconD.DoctorTables
                     where x.DoctorId == apt.DoctorId
                     select x).First();

        var aptDept = (from x in dbconS.DepartmentTables
                     where x.DepartmentId == aptDoc.DepartmentId
                     select x).First();

        var aptHos = (from x in dbconH.HospitalTables
                     where x.HospitalId == aptDept.HospitalId
                     select x).First();

        selectedAptDateLabel.Text = apt.AppointmentDate.ToShortDateString();
        selectedAptTimeLabel.Text = apt.AppointmentTime.ToString();
        selectedAptLocationLabel.Text = aptHos.Name;
        selectedAptDepartmentLabel.Text = aptDept.Specialization;
        selectedAptDoctorLabel.Text = aptDoc.Name;
        selectedAptReasonLabel.Text = apt.Description;
    }

    protected void hospitalDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedHospital = Convert.ToInt32(hospitalDropDownList.SelectedItem.Value);

        HOSEntities dbconH = new HOSEntities();
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

        HOSEntities dbconH = new HOSEntities();
        dbconH.DepartmentTables.Load();

        var deptId = (from x in dbconH.DepartmentTables
                      where x.Specialization == selectedDepartment
                      select x.DepartmentId).First();

        HOSEntities dbconD = new HOSEntities();
        dbconD.DoctorTables.Load();
        var doc = from x in dbconD.DoctorTables.Local
                  where x.DepartmentId == deptId
                  select x.Name;

        doctorDropDownList.DataSource = doc.ToList();
        doctorDropDownList.DataBind();
    }

    protected void updateAppointmentButton_Click(object sender, EventArgs e)
    {
        //current Appointment information
        HOSEntities dbconA = new HOSEntities();
        HOSEntities dbconD = new HOSEntities();
        HOSEntities dbconH = new HOSEntities();
        HOSEntities dbconS = new HOSEntities();

        int selectedAppointment = (int)UpcomingAppointmentsGridView.SelectedDataKey[0];

        var apt = (from x in dbconA.AppointmentTables
                   where x.AppointmentId == selectedAppointment
                   select x).First();

        var aptDoc = (from x in dbconD.DoctorTables
                      where x.DoctorId == apt.DoctorId
                      select x).First();

        var aptDept = (from x in dbconS.DepartmentTables
                       where x.DepartmentId == aptDoc.DepartmentId
                       select x).First();

        var aptHos = (from x in dbconH.HospitalTables
                      where x.HospitalId == aptDept.HospitalId
                      select x).First();

        DateTime currentAppDate = apt.AppointmentDate;
        TimeSpan currentAppTime = apt.AppointmentTime;
        string currentAppHospital = aptHos.Name;
        string currentAppSpecialization = aptDept.Specialization;
        string currentAppDocName = aptDoc.Name;
        string currentAppDescription = apt.Description;

        //Compare new selections with current appointment data
        DateTime editAppDate = currentAppDate;
        TimeSpan editAppTime = currentAppTime;
        string editAppReason = currentAppDescription;
        string editAppDoctorName = currentAppDocName;
        int editAppDoctor = aptDoc.DoctorId;
        
        if (appointmentDateCalendar.SelectedDate != DateTime.MinValue)
        {
            editAppDate = Convert.ToDateTime(appointmentDateCalendar.SelectedDate);
        }
        if ((hourDropDownList.SelectedIndex != -1) && (minuteDropDownList.SelectedIndex != -1))
        {
            editAppTime = new TimeSpan(Convert.ToInt32(hourDropDownList.SelectedValue), Convert.ToInt32(minuteDropDownList.SelectedValue), 0);
        }
        if(!(reasonTextBox.Text.Equals("")))
        {
            editAppReason = reasonTextBox.Text;
        }
        if(!(doctorDropDownList.SelectedItem.Value.Equals(currentAppDocName)))
        {
            editAppDoctorName = doctorDropDownList.SelectedItem.Value;
            HOSEntities dbconD2 = new HOSEntities();
            var editAppDoc = (from x in dbconD2.DoctorTables
                              where x.Name == editAppDoctorName
                              select x).First();
            editAppDoctor = editAppDoc.DoctorId;
        }


        //verify input is still valid
        //verify date is in the future
        if (editAppDate <= DateTime.Today)
        {
            confirmationLabel.Text = "Please reschedule your appointment for a future date.";
        }

        else
        {
            //date and time is free for patient and doctor


            HOSEntities dbconA2 = new HOSEntities();
            var existApp = (from x in dbconA2.AppointmentTables
                            where x.AppointmentDate == editAppDate
                            select x).FirstOrDefault();


            HOSEntities dbconA3 = new HOSEntities();
            var existAppDoc = (from x in dbconA3.AppointmentTables
                               where x.DoctorId == editAppDoctor
                               select x).FirstOrDefault();

            if (existApp != null) //there is already an appointment on the selected date
            {
                if (existApp.PatientId == userID) //the appointment belongs to the patient/user
                {
                    if (existApp.AppointmentTime == editAppTime) //the appointment is for the same time
                    {
                        confirmationLabel.Text = "You already have an appointment for that day and time, please select another day or time to make your appointment.";
                    }
                }

                if (existAppDoc != null) //the appointment belongs to the selected doctor
                {
                    if (existAppDoc.AppointmentTime == editAppTime) //appointment is for the same time
                    {
                        confirmationLabel2.Text = "The selected doctor already has an appointment for that day and time, please select another day or time, or a different doctor to make your appointment.";
                    }
                }
            }
            else //input is valid, update appointment
            {
                //selected appointment is apt, update all fields to ensure the record is valid and accurate
                dbcon = new HOSEntities();
                var updatedApt = (from x in dbcon.AppointmentTables
                           where x.AppointmentId == selectedAppointment
                           select x).First();
                updatedApt.AppointmentDate = editAppDate;
                updatedApt.AppointmentTime = editAppTime;
                updatedApt.Description = editAppReason;
                updatedApt.DoctorId = editAppDoctor;
                updatedApt.PatientId = userID;

                dbcon.SaveChanges();

                //clear form
                appointmentDateCalendar.SelectedDates.Clear();
                hourDropDownList.SelectedIndex = -1;
                minuteDropDownList.SelectedIndex = -1;
                hospitalDropDownList.SelectedIndex = -1;
                departmentDropDownList.Items.Clear();
                doctorDropDownList.Items.Clear();
                reasonTextBox.Text = "";

                //confirm appointment
                confirmationLabel.Text = "Appointment was successfully updated!";
                confirmationLabel2.Text = "We will see you on " + editAppDate.ToShortDateString() + " at " + editAppTime + " for your appointment with " + editAppDoctorName + " for " + editAppReason;
                RefreshGridView();
            }
        }
    }

    protected void cancelButton_Click(object sender, EventArgs e)
    {
        //clear selected appointment values from labels
        selectedAptDateLabel.Text = "--select appointment--";
        selectedAptTimeLabel.Text = "--select appointment--";
        selectedAptLocationLabel.Text = "--select appointment--";
        selectedAptDepartmentLabel.Text = "--select appointment--";
        selectedAptDoctorLabel.Text = "--select appointment--";
        selectedAptReasonLabel.Text = "--select appointment--";

        //clear gridview selection
        UpcomingAppointmentsGridView.SelectedIndex = -1;

        //clear form values
        appointmentDateCalendar.SelectedDates.Clear();
        hourDropDownList.SelectedIndex = -1;
        minuteDropDownList.SelectedIndex = -1;
        hospitalDropDownList.SelectedIndex = -1;
        departmentDropDownList.Items.Clear();
        doctorDropDownList.Items.Clear();
        reasonTextBox.Text = "";
    }

}