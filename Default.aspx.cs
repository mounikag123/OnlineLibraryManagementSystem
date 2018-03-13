using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bs"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    string sql_query;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Add_Click(object sender, EventArgs e)
    {
        try
        {
            sql_query = "Insert into BookRecord(bookid, bookname, bookpubname, bookpubyear, bookprice, bookquantity, recorddate) values('" + txt_bookid.Text.Trim() + "','" + txt_bookname.Text.Trim() + "','" + txt_bookpubname.Text.Trim() + "','" + txt_bookpubyear.Text.Trim() + "','" + txt_bookprice.Text.Trim() + "','" + txt_bookqty.Text.Trim() + "','" + DateTime.Today.Date.ToShortDateString() + "')";
            cmd = new SqlCommand(sql_query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lblresult.Text = "Record Inserted Successfully...";
        }
        catch
        {
            con.Close();
        }
    }
    protected void btn_Add_Reset_Click(object sender, EventArgs e)
    {
        ResetTextbox();
    }
    private void ResetTextbox()
    {
        txt_bookid.Text = "";
        txt_bookname.Text = "";
        txt_bookpubname.Text = "";
        txt_bookpubyear.Text = "";
        txt_bookprice.Text = "";
        txt_bookqty.Text = "";        
    }
    private void ResetEditTextbox()
    {
        txt_edit_bookid.Text = "";
        txt_edit_bookid.Style.Add("width", "235px");
        txt_edit_bookid.Style.Add("background", "#ffffff");
        txt_edit_bookid.ReadOnly = false;

        btn_check.Visible = true;
        txt_edit_bookname.Text = "";
        txt_edit_bookpubname.Text = "";
        txt_edit_bookpubdate.Text = "";
        txt_edit_bookprice.Text = "";
        txt_edit_bookqty.Text = "";
    }
    private void ResetDeleteTextbox()
    {
        txt_delete_bookid.Text = "";
    }

    private void DisableReadOnly_EditTextBoxColor()
    {
        txt_edit_bookname.ReadOnly = true;
        txt_edit_bookname.Style.Add("background", "#dddddd");
        txt_edit_bookpubname.ReadOnly = true;
        txt_edit_bookpubname.Style.Add("background", "#dddddd");
        txt_edit_bookpubdate.ReadOnly = true;
        txt_edit_bookpubdate.Style.Add("background", "#dddddd");
        txt_edit_bookprice.ReadOnly = true;
        txt_edit_bookprice.Style.Add("background", "#dddddd");
        txt_edit_bookqty.ReadOnly = true;
        txt_edit_bookqty.Style.Add("background", "#dddddd");
    }
    protected void btn_Add_Cancel_Click(object sender, EventArgs e)
    {
        ResetTextbox();
    }

    // Check Book Detail through BookID
    protected void btn_check_Click(object sender, EventArgs e)
    {
        try
        {
            sql_query = "Select * from BookRecord Where bookid='" + txt_edit_bookid.Text.Trim() + "'";
            da = new SqlDataAdapter(sql_query, con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_edit_bookid.Text = ds.Tables[0].Rows[0]["bookid"].ToString();
                txt_edit_bookname.Text = ds.Tables[0].Rows[0]["bookname"].ToString();
                txt_edit_bookpubname.Text = ds.Tables[0].Rows[0]["bookpubname"].ToString();
                txt_edit_bookpubdate.Text = ds.Tables[0].Rows[0]["bookpubyear"].ToString();
                txt_edit_bookprice.Text = ds.Tables[0].Rows[0]["bookprice"].ToString();
                txt_edit_bookqty.Text = ds.Tables[0].Rows[0]["bookquantity"].ToString();
                btn_check.Visible = false;
                
                EnableReadOnly_TextBoxColor();

                div_add.Style.Add("display", "none");
                table_Add.Style.Add("display", "none");
                div_edit.Style.Add("display", "block");
                table_Edit.Style.Add("display", "block");
                div_delete.Style.Add("display", "none");
                table_Delete.Style.Add("display", "none");


                txt_edit_bookid.Style.Add("width", "300px");
                txt_edit_bookid.Style.Add("background", "#dddddd");
                txt_edit_bookid.ReadOnly = true;
            }
        }
        catch
        {
            con.Close();
        }
    }

    private void EnableReadOnly_TextBoxColor()
    {
        txt_edit_bookid.ReadOnly = false;
        txt_edit_bookid.Style.Add("background","#ffffff");
        txt_edit_bookname.ReadOnly = false;
        txt_edit_bookname.Style.Add("background","#ffffff");
        txt_edit_bookpubname.ReadOnly = false;
        txt_edit_bookpubname.Style.Add("background","#ffffff");
        txt_edit_bookpubdate.ReadOnly = false;
        txt_edit_bookpubdate.Style.Add("background","#ffffff");
        txt_edit_bookprice.ReadOnly = false;
        txt_edit_bookprice.Style.Add("background","#ffffff");
        txt_edit_bookqty.ReadOnly = false;
        txt_edit_bookqty.Style.Add("background","#ffffff");
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            sql_query = "Update BookRecord set bookname='" + txt_edit_bookname.Text.Trim() + "', bookpubname='" + txt_edit_bookpubname.Text.Trim() + "', bookpubyear='" + txt_edit_bookpubdate.Text.Trim() + "', bookprice='" + txt_edit_bookprice.Text.Trim() + "', bookquantity='" + txt_edit_bookqty.Text.Trim() + "' where bookid='" + txt_edit_bookid.Text.Trim() + "'";
            cmd = new SqlCommand(sql_query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lblresult.Text = "Record Updated Successfully...";
        }
        catch
        {
            con.Close();
        }
    }
    protected void btn_Update_Reset_Click(object sender, EventArgs e)
    {
        ResetEditTextbox();
        DisableReadOnly_EditTextBoxColor();
    }
    protected void btn_Update_Cancel_Click(object sender, EventArgs e)
    {
        ResetEditTextbox();
        DisableReadOnly_EditTextBoxColor();
    }

    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            sql_query = "Delete BookRecord where bookid='" + txt_delete_bookid.Text.Trim() + "'";
            cmd = new SqlCommand(sql_query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            div_add.Style.Add("display", "none");
            table_Add.Style.Add("display", "none");
            div_edit.Style.Add("display", "none");
            table_Edit.Style.Add("display", "none");
            div_delete.Style.Add("display", "block");
            table_Delete.Style.Add("display", "block");

            lblresult.Text = "Record Deleted Successfully...";
        }
        catch
        {
            con.Close();
        }
    }
    protected void btn_Delete_Reset_Click(object sender, EventArgs e)
    {
        ResetDeleteTextbox();
    }
    protected void btn_Delete_Cancel_Click(object sender, EventArgs e)
    {
        ResetDeleteTextbox();
    }
}