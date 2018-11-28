using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyWork_Email : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (isDoctor())
        {
            Response.Redirect("MessagesMain.aspx");
        }
        else
            Response.Redirect("PatientMessageInbox.aspx");
    }

    public bool isDoctor()
    {
        if (User.Identity.Name.Length >= 6)
        {
            if (User.Identity.Name.Substring(0, 6) == "doctor")
                return true;
        }

        return false;

    }
}