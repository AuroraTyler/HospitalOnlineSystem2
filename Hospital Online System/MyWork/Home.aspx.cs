using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyWork_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(isDoctor())
        {
            Label1.Visible = true;
            HyperLink5.Visible = true;
            HyperLink4.Visible = true;
        }
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}