using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class PrescriptionsResults : System.Web.UI.Page
{

    TGDBEntities dbcon = new TGDBEntities();
    int userID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/MyWork/Home.aspx");
        }

        RefreshTestGridView();
        RefreshPrescriptionGridView();

    }

    protected void RefreshTestGridView()
    {
        if (dbcon != null)
            dbcon.Dispose();

        TGDBEntities dbconD = new TGDBEntities();

        var docUser = (from x in dbconD.PatientTables
                       where x.PatientUserName == User.Identity.Name
                       select x).First();

        userID = docUser.PatientId;

        TGDBEntities dbconA = new TGDBEntities();
        dbconA.TestTables.Where(item => item.PatientID.Equals(userID)).Load();

        TestGridview.DataSource = dbconA.TestTables.Local;
        TestGridview.DataBind();
    }

    protected void RefreshPrescriptionGridView()
    {
        if (dbcon != null)
            dbcon.Dispose();

        TGDBEntities dbconZ = new TGDBEntities();

        var docUser = (from x in dbconZ.PatientTables
                       where x.PatientUserName == User.Identity.Name
                       select x).First();

        userID = docUser.PatientId;

        TGDBEntities dbconY = new TGDBEntities();
        dbconY.PrescriptionTables.Where(item => item.PatientID.Equals(userID)).Load();

        PrescriptionsGridview.DataSource = dbconY.PrescriptionTables.Local;
        PrescriptionsGridview.DataBind();
    }
}

