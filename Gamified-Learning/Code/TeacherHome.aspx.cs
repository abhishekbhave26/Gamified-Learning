using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Teacher : System.Web.UI.Page
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
            sem = Session["sem"].ToString();
            branch = Session["branch"].ToString();
            subject = Session["subject"].ToString();
            Label1.Text = username;
            
            if (!IsPostBack)
            {
                showquestions();
            }
        }
    }
    private void showquestions()
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from questions where subject='" + subject + "' order by qid ASC", con);
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
            Label2.Text = "No Questions to display!";
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int qid = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text);
        string question = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select max(qid) as count from questions where subject='" + subject + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            int count = Convert.ToInt32(ds.Tables[0].Rows[0]["count"]);
            if (count==qid)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("delete from questions where qid='" + qid + "' and subject='" + subject + "'", con);
                cmd1.ExecuteNonQuery();
                con.Close();

                showquestions();
            }
            else if (count > 1)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update questions set qid='" + qid + "' where qid='" + count + "' and subject='" + subject + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();


    

                con.Open();
                SqlCommand cmd1 = new SqlCommand("delete from questions where qid='" + qid + "' and subject='" + subject + "' and question = '" + question + "'", con);
                cmd1.ExecuteNonQuery();
                con.Close();

                showquestions();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from questions where qid='" + qid + "' and subject='" + subject + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();

                showquestions();
            }
        }
    }
}