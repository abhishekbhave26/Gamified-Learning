using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class StartTest : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    string username, selectedsubject,result;
    static int[] qid = new int[10];
    int count = 0, Count = 10;
    int p, wa, fs;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {

            // Panel2.Visible = false;
            Panel3.Visible = true;
            username = Session["username"].ToString();
            selectedsubject = Session["selectedsubject"].ToString();
            if (!IsPostBack)
            {
                Label2.Text = count.ToString();
                Label5.Text = Session["min"].ToString();
                Label6.Text = Session["second"].ToString();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select qid from buffer where username='" + username + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        qid[i] = Convert.ToInt32(ds.Tables[0].Rows[i]["qid"]);
                    }
                    question();

                }
            }

        }
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Label2.Text) < 10)
        {
            Label2.Text = (Convert.ToInt32(Label2.Text) - 1).ToString();
            count--;

            //get answer
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select answer from questions where question='" + Label1.Text + "'  ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            //get skip
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select opt4 from questions where question='" + Label1.Text + "'  ", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();

            //answer check
            if (ds.Tables[0].Rows.Count > 0)
            {
                int rans = 0, wans = 0, myans = 0;
                string ans = Label3.Text;
                string qid = Label9.Text;
                string actualans = ds.Tables[0].Rows[0]["answer"].ToString();


                if (ans == ds.Tables[0].Rows[0]["answer"].ToString())
                {
                    //correct
                    con.Open();
                    SqlDataAdapter da3 = new SqlDataAdapter("select * from test where username='" + username + "' and subject='" + selectedsubject + "'", con);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    con.Close();
                    rans = Convert.ToInt32(ds3.Tables[0].Rows[0]["rans"]);
                    wans = Convert.ToInt32(ds3.Tables[0].Rows[0]["wans"]);
                    myans = Convert.ToInt32(ds3.Tables[0].Rows[0]["myans"]);

                    myans = myans + 2;
                    rans = rans + 1;
                    
                    con.Open();

                    SqlCommand cmd = new SqlCommand("update test set myans='" + myans + "',rans='" + rans + "' where username='" + username + "' and subject = '" + selectedsubject + "'  ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                else
                {
                    if (ans == ds1.Tables[0].Rows[0]["opt4"].ToString())
                    {
                        //skip
                        wans = wans + 0;
                        rans = rans + 0;

                    }

                    else
                    {
                        //wrong 
                        con.Open();
                        SqlDataAdapter da3 = new SqlDataAdapter("select * from test where username='" + username + "' and subject='" + selectedsubject + "'", con);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3);
                        con.Close();
                        rans = Convert.ToInt32(ds3.Tables[0].Rows[0]["rans"]);
                        wans = Convert.ToInt32(ds3.Tables[0].Rows[0]["wans"]);
                        myans = Convert.ToInt32(ds3.Tables[0].Rows[0]["myans"]);


                        myans = myans - 1;
                        wans = wans + 1;
                        con.Open();
                        SqlCommand cmd = new SqlCommand("update test set myans='" + myans + "',wans='" + wans + "' where username='" + username + "'and subject = '" + selectedsubject + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            question();
        }

    }

    private void question()
    {
        //if (count < 10)
        if (Convert.ToInt32(Label2.Text) < 10)
        {
            
            
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select q.qid,q.question,q.opt1,q.opt2,q.opt3,q.opt4,q.answer from questions as q,buffer as b where b.qid='" + qid[Convert.ToInt32(Label2.Text)] + "' and b.subject='" + selectedsubject + "' and b.qid=q.qid and b.subject=q.subject", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = ds.Tables[0].Rows[0]["question"].ToString();
                    Label9.Text = ds.Tables[0].Rows[0]["qid"].ToString();


                    RadioButtonList1.ClearSelection();
                    RadioButtonList1.Items.Clear();
                    RadioButtonList1.Items.Add(ds.Tables[0].Rows[0]["opt1"].ToString());
                    RadioButtonList1.Items.Add(ds.Tables[0].Rows[0]["opt2"].ToString());
                    RadioButtonList1.Items.Add(ds.Tables[0].Rows[0]["opt3"].ToString());
                    RadioButtonList1.Items.Add(ds.Tables[0].Rows[0]["opt4"].ToString());

                }
            }
            
        }
    



    protected void Button2_Click(object sender, EventArgs e)
    {

        con.Open();
        con.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(Label2.Text) < 10)
        {
            Label2.Text = (Convert.ToInt32(Label2.Text) + 1).ToString();
            count++;

            //get answer
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select answer from questions where question='" + Label1.Text + "'  ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            //get skip
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select opt4 from questions where question='" + Label1.Text + "'  ", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();

            //answer check
            if (ds.Tables[0].Rows.Count > 0)
            {
                int rans = 0, wans = 0, myans = 0;
                string ans = Label3.Text;
                string qid = Label9.Text;

                string actualans = ds.Tables[0].Rows[0]["answer"].ToString();


                if (ans == ds.Tables[0].Rows[0]["answer"].ToString())
                {
                    //correct
                    con.Open();
                    SqlDataAdapter da3 = new SqlDataAdapter("select * from test where username='" + username + "' and subject='" + selectedsubject + "'", con);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    con.Close();
                    rans = Convert.ToInt32(ds3.Tables[0].Rows[0]["rans"]);
                    wans = Convert.ToInt32(ds3.Tables[0].Rows[0]["wans"]);
                    myans = Convert.ToInt32(ds3.Tables[0].Rows[0]["myans"]);

                    myans = myans + 2;
                    rans = rans + 1;
                    if (myans <= 8)
                        result = "Poor student with very little knowledge of CN basics.Special attention to be given to this student";
                    else if (myans <= 14)
                        result = "Good student.Can improve if given attention";
                    else
                        result = "Excellent student with robust knwoledge of the subject.Can be given harder coursework";
                    
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update test set myans='" + myans + "',result='" + result + "',rans='" + rans + "' where username='" + username + "' and subject = '" + selectedsubject + "'  ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                else
                {
                    if (ans == ds1.Tables[0].Rows[0]["opt4"].ToString())
                    {
                        //skip
                        wans = wans + 0;
                        rans = rans + 0;
                    }

                    else
                    {
                        //wrong 
                        con.Open();
                        SqlDataAdapter da3 = new SqlDataAdapter("select * from test where username='" + username + "' and subject='" + selectedsubject + "'", con);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3);
                        con.Close();
                        rans = Convert.ToInt32(ds3.Tables[0].Rows[0]["rans"]);
                        wans = Convert.ToInt32(ds3.Tables[0].Rows[0]["wans"]);
                        myans = Convert.ToInt32(ds3.Tables[0].Rows[0]["myans"]);


                        myans = myans - 1;
                        wans = wans + 1;
                        con.Open();
                        SqlCommand cmd = new SqlCommand("update test set myans='" + myans + "',wans='" + wans + "' where username='" + username + "'and subject = '" + selectedsubject + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            question();
        }

        if (Convert.ToInt32(Label2.Text) == 10)
        {
            Response.Redirect("Result.aspx");
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

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label3.Text = " ";
        Label3.Text = RadioButtonList1.SelectedItem.Value.ToString();

    }

    protected void Unnamed1_Tick(object sender, EventArgs e)
    {

        if (Label6.Text == "1" && Label5.Text != "0")
        {

            int m = Convert.ToInt32(Label5.Text);
            m = m - 1;
            Label5.Text = m.ToString();
            Session["min"] = Label5.Text;
            Label6.Text = "60";

        }
        int s = Convert.ToInt32(Label6.Text);
        s = s - 1;

        Label6.Text = s.ToString();
        Session["second"] = Label6.Text;
        if (Label5.Text == "0" && Label6.Text == "1")
        {
            Response.Write("<script language=javascript>alert('Test Over.')</script>");
            Response.Redirect("Result.aspx");
        }

    }
}