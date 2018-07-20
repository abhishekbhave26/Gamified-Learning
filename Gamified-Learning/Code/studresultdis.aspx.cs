using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class studresultdis : System.Web.UI.Page
{
    string username, sem, branch, subject;
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

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
            sem = Session["sem"].ToString();
            branch = Session["branch"].ToString();
            
            
             if (!IsPostBack)
            {
                showresult();
            }
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

    private void showresult()
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select username, subject, myans from test where username='" + username + "' order by myans ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);

      



        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {

            GridView1.Visible = true;
            GridView1.DataSource = ds;
            GridView1.DataBind();
            Label2.Visible = false;
        
         }
        else
        {
            GridView1.Visible = false;
            Label2.Text = "No Results to display!";
        }



    }
    protected void LinkButton(object sender, EventArgs e)
    {
        Response.Redirect("");
    }
}