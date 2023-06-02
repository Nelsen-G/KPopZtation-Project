using KPopZtation_Project.Model;
using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Handler
{
    public class CustomerHandler
    {

        private CustomerRepository customerRepository;

        public CustomerHandler()
        {
            customerRepository = new CustomerRepository();
        }

        public void HandleRegistration(string name, string email, string gender, string address, string password)
        {
            customerRepository.createCustomer(name, email, password, gender, address);
        }


        public void HandleUpdate(int id, string name, string email, string gender, string address, string password)
        {

            customerRepository.updateCustomer(id, name, email, gender, address, password);
        }


        public bool CheckLogin(string email, string password)
        {
            bool loginSuccess = customerRepository.ValidateCredentials(email, password);

            return loginSuccess;
        }

        public string GetUserName(string email)
        {
            return customerRepository.GetUserNameByEmail(email);
        }

        public string GetUserID(string email)
        {
            return customerRepository.GetUserIDByEmail(email);
        }

        public string GetRole(string email)
        {
            return customerRepository.GetRoleByEmail(email);
        }

        public bool checkEmail(String email)
        {
            return customerRepository.checkCustomerEmail(email);
        }


        public string GetCustomerEmail(int id)
        {
            return customerRepository.SelectCustomerEmail(id);
        }

        public bool Login(string email, string password, bool rememberMe, out string errorMessage)
        {
            CustomerHandler customerHandler = new CustomerHandler();
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

            // Cookie handling
            if (loginSuccess)
            {
                if (rememberMe)
                {
                    HttpCookie loginCookie = new HttpCookie("LoggedInUser");
                    loginCookie.Values["Email"] = email;
                    loginCookie.Values["Password"] = password;
                    loginCookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies.Add(loginCookie);
                }
                else
                {
                    if (HttpContext.Current.Request.Cookies["LoggedInUser"] != null)
                    {
                        HttpCookie loginCookie = new HttpCookie("LoggedInUser");
                        loginCookie.Expires = DateTime.Now.AddDays(-1);
                        HttpContext.Current.Response.Cookies.Add(loginCookie);
                    }
                }

                string customerRole = customerHandler.GetRole(email);

                if (customerRole == "cust")
                {
                    HttpContext.Current.Session["user"] = "Customer";
                }
                else if (customerRole == "admin")
                {
                    HttpContext.Current.Session["user"] = "Admin";
                    HttpContext.Current.Session["customerID"] = -1;
                }

                HttpContext.Current.Session["username"] = customerHandler.GetUserName(email);
                HttpContext.Current.Session["customerID"] = customerHandler.GetUserID(email);

                HttpContext.Current.Response.Redirect("HomePage.aspx");
            }

            if (email == "admin" && password == "admin")
            {
                if (rememberMe)
                {
                    HttpCookie loginCookie = new HttpCookie("LoggedInUser");
                    loginCookie.Values["Email"] = email;
                    loginCookie.Values["Password"] = password;
                    loginCookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies.Add(loginCookie);
                }
                else
                {
                    if (HttpContext.Current.Request.Cookies["LoggedInUser"] != null)
                    {
                        HttpCookie loginCookie = new HttpCookie("LoggedInUser");
                        loginCookie.Expires = DateTime.Now.AddDays(-1);
                        HttpContext.Current.Response.Cookies.Add(loginCookie);
                    }
                }

                HttpContext.Current.Session["user"] = "Admin";
                HttpContext.Current.Session["customerID"] = -1;
                HttpContext.Current.Response.Redirect("HomePage.aspx");
            }

            return loginSuccess;
        }


    }

}
