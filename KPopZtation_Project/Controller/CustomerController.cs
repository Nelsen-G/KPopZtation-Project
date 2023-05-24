using KPopZtation_Project.Handler;
using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Controller
{
    public class CustomerController
    {

        private CustomerHandler customerHandler;

        public CustomerController()
        {
            customerHandler = new CustomerHandler();
        }


        private bool IsPasswordAlphanumeric(string password)
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


        public void RegisterCustomer(string name, string email, string gender, string address, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Validate Name
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "Name must be filled";
                return;
            }
            else if (name.Length < 5 || name.Length > 50)
            {
                errorMessage = "Name must be between 5 and 50 characters";
                return;
            }

            // Validate Email
            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "Email must be filled";
                return;
            }
            else if (!customerHandler.checkEmail(email))
            {
                errorMessage = "Email is already used";
                return;
            }

            // Validate Gender
            if (string.IsNullOrEmpty(gender))
            {
                errorMessage = "Gender must be selected.";
                return;
            }

            // Validate Address
            if (string.IsNullOrEmpty(address))
            {
                errorMessage = "Address must be filled";
                return;
            }
            else if (!address.EndsWith("Street", StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = "Address must end with 'Street'";
                return;
            }

            // Validate Password
            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Password must be filled";
                return;
            }
            else if (!IsPasswordAlphanumeric(password))
            {
                errorMessage = "Password must be alphanumeric";
                return;
            }


            customerHandler.HandleRegistration(name, email, gender, address, password);
        }


        public bool Login(string email, string password, bool rememberMe, out string errorMessage)
        {

            bool loginSuccess = customerHandler.CheckLogin(email, password);

            errorMessage = string.Empty;


            //Sistem Validasi empty dan invalid
            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "Email must be filled";
            }

            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Password must be filled";
            }

            if (!loginSuccess)
            {
                errorMessage = "Invalid email or password";
            }


            //Sistem simpan cookies
            if (loginSuccess)
            {
                if (rememberMe) // Checkbox is checked
                {
                    // Create or update the login cookie
                    HttpCookie loginCookie = new HttpCookie("LoggedInUser");
                    loginCookie.Values["Email"] = email;
                    loginCookie.Values["Password"] = password;
                    loginCookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies.Add(loginCookie);
                }
                else // Checkbox is unchecked
                {
                    // Remove login cookie
                    if (HttpContext.Current.Request.Cookies["LoggedInUser"] != null)
                    {
                        HttpCookie loginCookie = new HttpCookie("LoggedInUser");
                        loginCookie.Expires = DateTime.Now.AddDays(-1);
                        HttpContext.Current.Response.Cookies.Add(loginCookie);
                    }
                }

                HttpContext.Current.Session["user"] = "Customer";
                HttpContext.Current.Session["username"] = customerHandler.GetUserName(email);
                HttpContext.Current.Session["customerID"] = customerHandler.GetUserID(email);

                HttpContext.Current.Response.Redirect("HomePage.aspx");
            }

            return loginSuccess;

        }



    }
}