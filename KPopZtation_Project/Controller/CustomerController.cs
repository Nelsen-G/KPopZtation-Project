using KPopZtation_Project.Handler;
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

        public void RegisterCustomer(string name, string email, string gender, string address, string password, out string errorMessage)
        {
            customerHandler.HandleRegistration(name, email, gender, address, password, out errorMessage);
        }


        public bool Login(string email, string password, bool rememberMe, out string errorMessage)
        {

            bool loginSuccess = customerHandler.CheckLogin(email, password, out errorMessage);

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
                    // Remove the login cookie
                    if (HttpContext.Current.Request.Cookies["LoggedInUser"] != null)
                    {
                        HttpCookie loginCookie = new HttpCookie("LoggedInUser");
                        loginCookie.Expires = DateTime.Now.AddDays(-1);
                        HttpContext.Current.Response.Cookies.Add(loginCookie);
                    }
                }

                HttpContext.Current.Session["user"] = "Customer";
                HttpContext.Current.Session["username"] = customerHandler.GetUserName(email);

                HttpContext.Current.Response.Redirect("HomePage.aspx");
            }

            return loginSuccess;

        }



    }
}