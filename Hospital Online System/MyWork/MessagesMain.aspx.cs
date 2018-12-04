using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class MyWork_MessagesMain : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Refresh();
        }

    }
    void Refresh()
    {
        if (dbcon != null)
            dbcon.Dispose();
        dbcon = new TGDBEntities();
        dbcon.EmailTables.Where(item => item.RecipientUserName.Trim().Equals(User.Identity.Name.Trim())).Load();

        //add data to the GridView
        GridView1.DataSource = dbcon.EmailTables.Local;
        GridView1.DataBind();
    }
    TGDBEntities dbcon;

    public void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
       
        
            TextBox1.Text = string.Empty;
            TextBox1.Visible = true;
            TextBox1.Text = (GridView1.SelectedDataKey[0].ToString());
        

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      
        
    }



    protected void Button2_Click1(object sender, EventArgs e)
    {
        TextBox1.Visible = false;
        
        dbcon = new TGDBEntities();
        dbcon.EmailTables.Load();

        int tape = (int)GridView1.SelectedDataKey[1];
        EmailTable abc;

        abc = (from x in dbcon.EmailTables
               where x.EmailId == tape
               select x).First();

        if (abc != null)
        {
            dbcon.EmailTables.Remove(abc);
            dbcon.SaveChanges();
        }

        Refresh();
    }
}

    