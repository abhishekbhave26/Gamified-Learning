using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    string username;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            username = Session["username"].ToString();
            Label1.Text = username;
            if (!IsPostBack)
                show_staff();
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

    private void show_staff()
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from staffreg", con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        

    }
}