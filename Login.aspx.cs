using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("FinalMainPage.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Hardcoded credentials (replace with database validation if needed)
            if (username == "admin" && password == "password123")
            {
                Session["User"] = username; 
                Response.Redirect("FinalMainPage.aspx"); 
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }
}