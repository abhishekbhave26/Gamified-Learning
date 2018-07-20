using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        if (txtusername.Text == "admin" && txtpassword.Text == "admin")
        {
            Session["username"] = txtusername.Text;

            Response.Redirect("AdminHome.aspx");
        }
        else if (DropDownList1.SelectedValue.ToString() == "null")
        { 
        //please select
        }
        else if (DropDownList1.SelectedValue.ToString() == "staff")
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from staffreg where tusername='"+txtusername.Text+"' and tpassword='"+txtpassword.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count>0)
            {
                string sem = ds.Tables[0].Rows[0]["tsem"].ToString();
                string branch = ds.Tables[0].Rows[0]["tbranch"].ToString();
                string subject = ds.Tables[0].Rows[0]["tsubject"].ToString();

                Session["username"] = txtusername.Text;
                Session["sem"] = sem;
                Session["branch"] = branch;
                Session["subject"] = subject;

                Response.Redirect("TeacherHome.aspx");

            }
        }
        else if (DropDownList1.SelectedValue.ToString() == "student")
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from registration where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string sem = ds.Tables[0].Rows[0]["sem"].ToString();
                string branch = ds.Tables[0].Rows[0]["branch"].ToString();

                Session["username"] = txtusername.Text;
                Session["sem"] = sem;
                Session["branch"] = branch;

                Response.Redirect("StudentHome.aspx");

            }
        }
    }
}