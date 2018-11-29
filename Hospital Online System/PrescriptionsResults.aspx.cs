using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class PrescriptionsResults : System.Web.UI.Page
{

    HOSEntities dbcon = new HOSEntities();
    int userID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/MyWork/Home.aspx");
        }

        RefreshGridView(TestGridview);
        RefreshGridView(PrescriptionsGridview);

    }

    protected void RefreshTestGridView()
    {
        if (dbcon != null)
            dbcon.Dispose();

        HOSEntities dbconD = new HOSEntities();

        var docUser = (from x in dbconD.PatientTables
                       where x.PatientUserName == User.Identity.Name
                       select x).First();

        userID = docUser.PatientId;

        HOSEntities dbconA = new HOSEntities();
        dbconA.TestTables.Where(item => item.PatientId.Equals(userID)).Load();

        TestGridview.DataSource = dbconA.AppointmentTables.Local;
        TestGridview.DataBind();
    }

    protected void RefreshPrescriptionGridView()
    {
        if (dbcon != null)
            dbcon.Dispose();

        HOSEntities dbconZ = new HOSEntities();

        var docUser = (from x in dbconZ.PatientTables
                       where x.PatientUserName == User.Identity.Name
                       select x).First();

        userID = docUser.PatientId;

        HOSEntities dbconA = new HOSEntities();
        dbconA.PrescriptionTables.Where(item => item.PatientId.Equals(userID)).Load();

        PrescriptionGridview.DataSource = dbconA.AppointmentTables.Local;
        PrescriptionGridview.DataBind();
    }
}
