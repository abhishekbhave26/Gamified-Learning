using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
         Label1.Text   = Session["username"].ToString();
        }
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["subject"] = null;
        Session["sem"] = null;
        Session["branch"] = null;
        Session["selectedsubject"] = null;
        Response.Redirect("Default.aspx");
    }
}