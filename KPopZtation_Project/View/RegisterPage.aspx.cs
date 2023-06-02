using KPopZtation_Project.Controller;
using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            string name = tbName.Text;
            string email = tbEmail.Text;
            string gender = rbGender.SelectedValue;
            string address = tbAddress.Text;
            string password = tbPassword.Text;

            CustomerController customerController = new CustomerController();

            string errorMessage;
            customerController.RegisterCustomer(name, email, gender, address, password, out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                lbErrorMessage.Text = errorMessage;
                return;
            }

            Response.Redirect("LoginPage.aspx");
        }
    }
}