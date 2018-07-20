using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Registration : System.Web.UI.Page
{
    SqlConnection con=new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsumbit_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select username from registration where username='"+txtusername.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        con.Close();
        if (ds.Tables[0].Rows.Count>0)
        {
            //username is already taken
            Response.Write("<script LANGUAGE=JavaScript>alert('Username Is Already Taken')</script>");
            txtclear();
        }
        else
        { 

        con.Open();
        SqlCommand cmd = new SqlCommand("insert into registration values('"+txtname.Text+"','"+txtusername.Text+"','"+txtpassword.Text+"','"+txtemail.Text+"','"+txtmobile.Text+"','"+ddlsem.Text+"','"+ddlbranch.Text+"')", con);
        cmd.ExecuteNonQuery();

        Response.Write("<script LANGUAGE=JavaScript>alert('Registartion Successfull')</script>");
        con.Close();

        
        txtclear();
        Response.Redirect("Default.aspx");
        }
    }
    private void txtclear()
    {
        txtname.Text = "";
        txtpassword.Text = "";
        txtusername.Text = "";
        txtemail.Text = "";
        txtmobile.Text = "";
    }
    
}