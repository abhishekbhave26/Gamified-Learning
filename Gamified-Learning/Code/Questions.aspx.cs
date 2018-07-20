using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Questions : System.Web.UI.Page
{
    string username,sem,branch,subject;
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
            sem = Session["sem"].ToString();
            branch = Session["branch"].ToString();
            subject = Session["subject"].ToString();
            Label1.Text = username;
        }
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["sem"] = null;
        Session["branch"] = null;
        Session["subject"] = null;
        Response.Redirect("Default.aspx");
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int id;
        int newid;
        con.Open();
        SqlDataAdapter daa = new SqlDataAdapter("select * from questions where subject='" + subject + "'", con);
        DataSet dss = new DataSet();
        daa.Fill(dss);

        con.Close();
        if (dss.Tables[0].Rows.Count>0)
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select max(qid) as maxid from questions where subject='" + subject + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["maxid"]);
                newid = id + 1;
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into questions values(" + newid + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + sem + "','" + branch + "','" + subject + "','no','" + null + "','" + null + "','" + null + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                clearall();
                Response.Write("<script LANGUAGE=JavaScript>alert('Questions Added Successfully')</script>");
            }
        }
       
        else
        { 
            id = 1;
            newid = 1;
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into questions values(" + newid + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + sem + "','" + branch + "','" + subject + "','no','null','null')", con);
            cmd.ExecuteNonQuery();

            con.Close();
            clearall();
            Response.Write("<script LANGUAGE=JavaScript>alert('Questions Added Successfully')</script>");
        }
    }
    private void clearall()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";

    }
}