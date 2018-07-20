using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
public partial class Result : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    string username,selectedsubject ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {   
            username = Session["username"].ToString();
            selectedsubject = Session["selectedsubject"].ToString();
            Label1.Text = Session["username"].ToString();
            if (!IsPostBack)
            {

                //clearing buffer table
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from buffer", con);
                cmd.ExecuteNonQuery();
                con.Close();

                //getting record from test table to display in graph
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select myans,rans,wans from test where username='" + username + "'and subject = '" + selectedsubject + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                { 
                     
                     Label5.Text = ds.Tables[0].Rows[0]["myans"].ToString();
                     Label4.Text = ds.Tables[0].Rows[0]["wans"].ToString();
                     Label3.Text = ds.Tables[0].Rows[0]["rans"].ToString();
                    
                    int rans=Convert.ToInt32( Label3.Text);
                    int wans=Convert.ToInt32( Label4.Text);
                    int[] yvalues = { rans, wans };
                    string[] xvalues = { "Right Answer=" + "" + rans + "", "Wrong Answer=" + "" + wans + "" };
                    Chart1.Series["Series1"].Points.DataBindXY(xvalues, yvalues);
                    Chart1.Series["Series1"].Points[0].Color = Color.Red;
                    Chart1.Series["Series1"].Points[1].Color = Color.Blue;
                    Chart1.Series["Series1"]["PieLabelStyle"] = "Disabled";
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    Chart1.Legends[0].Enabled = true;
                }
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
}