using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Pending : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bs"].ConnectionString);
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    String query;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void txt_bookid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_studentid.Text = "";
                query = "select a.bookid, s.studentid, s.studentname, a.assigneddate, a.returndate, a.penality, Status=(Select statusname from statusdetails where statusid=a.statusid) from Assign a inner join Student s ON a.studentid=s.studentid where bookid='" + txt_bookid.Text.Trim() + "'";
                da = new SqlDataAdapter(query, con);
                con.Open();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Grd_Pending_Status.DataSource = ds;
                    Grd_Pending_Status.DataBind();
                }
            }
            catch
            {
                con.Close();
            }
    }
    protected void Grd_Pending_Status_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                da = new SqlDataAdapter(query, con);
                //Find the DropDownList in the Row
                DropDownList ddl_status = (e.Row.FindControl("ddl_status") as DropDownList);
                //Select the Country of Customer in DropDownList                
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select statusid, statusname from statusdetails", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ddl_status.DataSource = ds1;
                        ddl_status.DataTextField = "statusname";
                        ddl_status.DataValueField = "statusid";
                        ddl_status.DataBind();
                        string status = (e.Row.FindControl("lblstatus") as Label).Text;
                        ddl_status.Items.FindByText(status).Selected = true;
                        //Add Default Item in the DropDownList
                        ddl_status.Items.Insert(0, new ListItem("Please select"));
                    }
                }
            }
        }
        catch
        {
            con.Close();
        }
    }
       

    protected void ddl_status_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl_status = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl_status.Parent.Parent;
            int idx = row.RowIndex;
            string statuschangedate = DateTime.Today.Date.ToShortDateString();

            
            //Retrieve bookid and studentid from Gridview and status(dropdownlist)
            String lblbookid = ((Label)row.Cells[0].FindControl("lblbookid")).Text;
            String lblstudentid = ((Label)row.Cells[0].FindControl("lblstudentid")).Text;
            DropDownList ddl = (DropDownList)row.Cells[0].FindControl("ddl_status");

            
            //Update Status            
            string query = "Update Assign set statusid='" + ddl.SelectedValue.ToString() + "', updatestatusdate='" + statuschangedate + "' where bookid='" + lblbookid + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();

            
            //cmd.ExecuteNonQuery();
            lblresult.Text = "Student : " + lblstudentid.ToString() + " Status is : <b>" + ddl.SelectedItem.Text.ToString() + "</b> Updated Successfully";
        }
        catch
        {
            con.Close();

        }
    }
    protected void txt_studentid_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txt_bookid.Text = "";
            query = "select Bookid, s.studentid, s.studentname, Assigneddate, returndate, Penality, Status=(Select statusname from statusdetails where statusid=a.statusid) from Assign a inner join Student s ON a.studentid=s.studentid Where a.studentid='" + txt_studentid.Text.Trim() + "'";
            da = new SqlDataAdapter(query, con);
            con.Open();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Grd_Pending_Status.DataSource = ds;
                Grd_Pending_Status.DataBind();
            }
        }
        catch
        {
            con.Close();
        }
    }
}