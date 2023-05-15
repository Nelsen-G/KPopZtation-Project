using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private bool IsPasswordAlphanumeric (string password)
        {
            bool hasAlphabetic = false;
            bool hasNumeric = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    hasAlphabetic = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumeric = true;
                }

                if (hasAlphabetic && hasNumeric)
                {
                    return true; // Alphanumeric Found
                }
            }

            return false; // No Alphanumeric
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {

            CustomerRepository customerCreation = new CustomerRepository();

            // Validate Name
            if (string.IsNullOrEmpty(tbName.Text))
            {
                lbErrorMessage.Text = "Name must be filled";
                return; 
            } else if (tbName.Text.Length < 5 || tbName.Text.Length > 50)
            {
                lbErrorMessage.Text = "Name must be between 5 and 50 characters";
                return;
            }

            // Validate Email 
            string email = tbEmail.Text.Trim();
            if (string.IsNullOrEmpty(email)) 
            {
                lbErrorMessage.Text = "Email must be filled";
                return;
            } else if (!customerCreation.checkCustomerEmail(email))
            {
                lbErrorMessage.Text = "Email is already used";
                return;
            }

            // Validate Gender
            if (string.IsNullOrEmpty(rbGender.SelectedValue))
            {
                lbErrorMessage.Text = "Gender must be selected.";
                return;
            }

            // Validate Address
            string address = tbAddress.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                lbErrorMessage.Text = "Address must be filled";
                return;
            } else if (!address.EndsWith("Street", StringComparison.OrdinalIgnoreCase))
            {
                lbErrorMessage.Text = "Address must end with 'Street'";
                return;
            }

            // Validate Password
            string password = tbPassword.Text;
            if (string.IsNullOrEmpty(password))
            {
                lbErrorMessage.Text = "Password must be filled";
                return;
            } else if (!IsPasswordAlphanumeric(password))
            {
                lbErrorMessage.Text = "Password must be alphanumeric";
                return;
            }

            customerCreation.createCustomer(tbName.Text, tbEmail.Text, tbPassword.Text, rbGender.SelectedValue.ToString(), tbAddress.Text);

            Response.Redirect("HomePage.aspx");
        }
    }
}