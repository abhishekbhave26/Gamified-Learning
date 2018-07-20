using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Verification : System.Web.UI.Page
{
    string otp, username;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"]==null)
        {
            Response.Redirect("Registration.aspx");
        }
        else
        {
            otp = Session["otp"].ToString();
            username = Session["username"].ToString();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (otp==txtotp.Text)
        {
            Response.Redirect("Home.aspx");
        }
    }
}