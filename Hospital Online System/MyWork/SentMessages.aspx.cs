using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class MyWork_SentMessages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        dbcon.EmailTables.Where(item => item.SenderUserName.Trim().Equals(User.Identity.Name.Trim())).Load();

        //add data to the GridView
        GridView1.DataSource = dbcon.EmailTables.Local;
        GridView1.DataBind();

    }

    TGDBEntities dbcon = new TGDBEntities();


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            Label1.Visible = false;
            TextBox1.Text = string.Empty;
            TextBox1.Visible = true;
            TextBox1.Text = (GridView1.SelectedDataKey[0].ToString());
        }
        catch (System.NullReferenceException)
        {
            TextBox1.Visible = false;
            Label1.Visible = true;
        }

    }
}