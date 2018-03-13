using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        try
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LIBRARYConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into Student (studentid,studentname,studentbranch,studentyear) values (@id,@name,@branch,@year)", conn);
            cmd.Parameters.AddWithValue("@id", txtStudentId.Text);
            cmd.Parameters.AddWithValue("@name", txtStudentName.Text);
            cmd.Parameters.AddWithValue("@branch", ddlBranch.SelectedValue );
            cmd.Parameters.AddWithValue("@year", ddlyear.SelectedValue);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                GridView1.DataBind();
                txtStudentId.Text = "";
                txtStudentName.Text = "";
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                conn.Close();
            }


        }
        catch (Exception ex)
        {

        }
        
    }
}