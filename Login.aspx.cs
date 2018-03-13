using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Request.Cookies["user"].Expires = DateTime.Now.AddMinutes(-30);
            Request.Cookies.Remove("user");
        }
        catch (Exception)
        {
                
          
        }
        
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (inputEmail.Value == "admin" && inputPassword.Value =="admin@123")
        {
            Response.Cookies["user"]["login"] = "true";
            Response.Redirect("Home.aspx");
        }
    }
}