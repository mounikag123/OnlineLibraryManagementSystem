using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class BookAssign : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bs"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da;
    DataSet ds;
    string sql_query;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Assign_Click(object sender, EventArgs e)
    {
        try
        {
            string returndate = DateTime.Today.AddDays(15).ToShortDateString();
            sql_query = "Insert into Assign (studentid, bookid, assigneddate, returndate, penality, statusid) values ('" + txt_assign_studentid.Text.Trim() + "','" + txt_assign_bookid.Text.Trim() + "','" + txt_assign_bookdate.Text.Trim() + "','" + returndate + "','0','s1')";
            cmd = new SqlCommand(sql_query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lblresult_bookassign.Text = "<b>Book ID :</b> " + txt_assign_bookid.Text + " is assigned to <b>Student ID :</b> " + txt_assign_studentid.Text + " on the <b>Date of :</b> " + txt_assign_bookdate.Text + " and you have to <b>return on Date :</b> " + returndate + " otherwise <b>Penality per day : </b> 5 Rupees.";
        }
        catch
        {
            con.Close();
        }
        
    }
    protected void txt_assign_bookid_TextChanged(object sender, EventArgs e)
    {
        try
        {
            sql_query = "Select * from BookRecord Where bookid='" + txt_assign_bookid.Text.Trim() + "'";
            da = new SqlDataAdapter(sql_query, con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_assign_bookid.Text = ds.Tables[0].Rows[0]["bookid"].ToString();
                txt_assign_bookname.Text = ds.Tables[0].Rows[0]["bookname"].ToString();
                txt_assign_bookqty.Text = ds.Tables[0].Rows[0]["bookquantity"].ToString();
                txt_assign_bookdate.Text = DateTime.Today.Date.ToShortDateString();
            }
        }
        catch
        {
            con.Close();
        }
    }
    protected void txt_assign_studentid_TextChanged(object sender, EventArgs e)
    {
        try
        {
            sql_query = "Select * from Student Where studentid='" + txt_assign_studentid.Text.Trim() + "'";
            da = new SqlDataAdapter(sql_query, con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_assign_studentid.Text = ds.Tables[0].Rows[0]["studentid"].ToString();
                txt_assign_studentname.Text = ds.Tables[0].Rows[0]["studentname"].ToString();
                txt_assign_studentbranch.Text = ds.Tables[0].Rows[0]["studentbranch"].ToString();
                txt_assign_studentyear.Text = ds.Tables[0].Rows[0]["studentyear"].ToString();
                
            }
        }
        catch
        {
            con.Close();
        }
    }
}