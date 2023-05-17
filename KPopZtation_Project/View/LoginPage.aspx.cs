using KPopZtation_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        CustomerController customerController = new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["LoggedInUser"] != null)
                {
                    string email = Request.Cookies["LoggedInUser"]["Email"];
                    string password = Request.Cookies["LoggedInUser"]["Password"];

                    tbEmail.Text = email;
                    tbPassword.Text = password;

                }


            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            bool rememberMe = cbRemember.Checked;

            string errorMessage;
            bool loginSuccess = customerController.Login(email, password, rememberMe, out errorMessage);

            if (!loginSuccess)
            {
                lbErrorMessage.Text = errorMessage;
            }
        }
    }
}