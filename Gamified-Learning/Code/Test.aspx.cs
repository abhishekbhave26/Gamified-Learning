using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Test : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    string username, sem, branch, subject;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null)
        {
            username = Session["username"].ToString();
            Label3.Text = username;
            sem = Session["sem"].ToString();
            Label5.Text = sem;
            branch = Session["branch"].ToString();
            Label4.Text = branch;
            if (!IsPostBack)
            {
                showsubjects();

            }
        }

    }
   private void showsubjects()
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select subj from subjects where sem='"+sem+"' and branch='"+branch+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
       if(ds.Tables[0].Rows.Count > 0)
       {
           DropDownList2.Items.Clear();
           DropDownList2.Items.Add("----Select----");
           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
           {
               string subj = ds.Tables[0].Rows[i][0].ToString();
               DropDownList2.Items.Add(subj);
           }
       }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //check if student already appeared for selected subject or not
        
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select * from test where username='" + username + "' and subject='"+Label1.Text+"'", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();

        if (ds1.Tables[0].Rows.Count > 0)
        {
            //not allow
            Response.Write("<script language=javascript>alert('You Already Given The Test For Selected Subject');</script>");
        }
        else
        {

           //genreting qid first for 10 questions
            int[] qid = new int[10];
            for (int i = 0; i < 10; i++)
            {
                con.Open();


                SqlDataAdapter da = new SqlDataAdapter("select * from questions where subject='" + Label1.Text + "' and status='no'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int count = ds.Tables[0].Rows.Count;
                    Random r = new Random();
                    int id = r.Next(0, count - 1);
                    qid[i] = Convert.ToInt32(ds.Tables[0].Rows[id]["qid"]);
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into buffer values('" + username + "','" + Label1.Text + "','" + qid[i] + "')", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    con.Open();

                    SqlCommand cmd = new SqlCommand("update questions set status='yes' where qid='" + qid[i] + "' and subject='" + Label1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                }
            }
            con.Open();
            SqlCommand cmd2 = new SqlCommand("update questions set status='no'", con);
            cmd2.ExecuteNonQuery();
            con.Close();

            //adding record to test table for score
            con.Open();
            SqlCommand cmd3 = new SqlCommand("insert into test values('" + username + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + Label1.Text + "','0','0','0','0')", con);
            cmd3.ExecuteNonQuery();

            con.Close();
            Session["min"] = 1;
            Session["second"] =30;
            Session["selectedsubject"] = Label1.Text;
            System.Threading.Thread.Sleep(5000);
            Response.Redirect("StartTest.aspx");
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
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Text = DropDownList2.SelectedItem.Text;
    }
}