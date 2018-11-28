using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appointments_appointments_redirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/MyWork/Home.aspx");
        }
        else
        {
            if (User.Identity.Name.Length >= 6) //if user is a doctor their username will contain Doctor
            {
                if (User.Identity.Name.Substring(0, 6) == "doctor")//if the user is a doctor redirect them to the apporpriate view_appointments page
                {
                    Response.Redirect("view_appointments_doctor.aspx");
                }
                else //if doctor is not in the username user is a patient, redirect them to the apporpriate view_appointments page
                {
                    Response.Redirect("view_appointments_patient.aspx");
                }

            }
            else //username is not long enough to contain doctor so user is a patient, redirect them to the apporpriate view_appointments page
            {
                Response.Redirect("view_appointments_patient.aspx");
            }
        }
    }
}