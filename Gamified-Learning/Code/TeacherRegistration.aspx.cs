using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class TeacherRegistration : System.Web.UI.Page
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
                showsem();
        }
    }
    private void showsem()
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select sem from subjects group by sem", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
         if (ds.Tables[0].Rows.Count > 0)
         {
             DropDownList1.Items.Clear();
             DropDownList1.Items.Add("----Select----");
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 string sem = ds.Tables[0].Rows[i][0].ToString();
                 DropDownList1.Items.Add(sem);
             }
         }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select tname from staffreg where tusername='"+TextBox2.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        { 
         // error
            Response.Write("<script LANGUAGE=JavaScript>alert('Username Is Already Taken')</script>");
            clearall();
        }
        else
        {
            con.Open();
            SqlDataAdapter daa = new SqlDataAdapter("select * from subjects where subj='" + DropDownList3.SelectedItem.Text + "' and status='taken'", con);
            DataSet dss = new DataSet();
            daa.Fill(dss);
            con.Close();

            if (dss.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script LANGUAGE=JavaScript>alert('Subject Is Already Taken')</script>");
                clearall();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into staffreg values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + DropDownList1.SelectedValue.ToString() + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList3.SelectedValue.ToString() + "','" + TextBox4.Text + "','" + TextBox5.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update subjects set status='taken' where subj='"+DropDownList3.SelectedItem.Text+"'", con);
                cmd1.ExecuteNonQuery();
                con.Close();
                Response.Write("<script LANGUAGE=JavaScript>alert('registartion Successfull')</script>");

                clearall();
            }
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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select branch from subjects where sem='"+DropDownList1.SelectedItem.Text+"' group by branch", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("----Select----");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string branch = ds.Tables[0].Rows[i][0].ToString();
                DropDownList2.Items.Add(branch);
            }
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select subj from subjects where branch='" + DropDownList2.SelectedItem.Text + "' and sem='"+DropDownList1.SelectedItem.Text+"' and status='available'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add("----Select----");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string branch = ds.Tables[0].Rows[i][0].ToString();
                DropDownList3.Items.Add(branch);
            }
        }
    }
}