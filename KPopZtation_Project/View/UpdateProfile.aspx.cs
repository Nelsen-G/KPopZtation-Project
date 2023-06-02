using KPopZtation_Project.Controller;
using KPopZtation_Project.Model;
using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();

            if (!IsPostBack)
            {
                string userRole = HttpContext.Current.Session["user"]?.ToString();

                if (userRole == "Admin")
                {
                    tbName.Text = string.Empty;
                    tbEmail.Text = string.Empty;
                    rbGender.ClearSelection();
                    tbAddress.Text = string.Empty;
                    tbPassword.Text = string.Empty;
                }
                else
                {
                    int customerID = customerRepository.GetCustomerID(HttpContext.Current);
                    Customer c = customerRepository.selectCustomer(customerID);

                    tbName.Text = c.CustomerName;
                    tbEmail.Text = c.CustomerEmail;
                    rbGender.SelectedValue = c.CustomerGender;
                    tbAddress.Text = c.CustomerAddress;
                    tbPassword.Text = c.CustomerPassword;
                }
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            CustomerController customerController = new CustomerController();
            string errorMessage;
            int customerID = customerRepository.GetCustomerID(HttpContext.Current);


            string name = tbName.Text;
            string email = tbEmail.Text;
            string gender = rbGender.SelectedValue;
            string address = tbAddress.Text;
            string password = tbPassword.Text;

            customerController.UpdateCustomer(customerID, name, email, gender, address, password, out errorMessage);


            if (!string.IsNullOrEmpty(errorMessage))
            {
                lbErrorMessage.Text = errorMessage;
                return;
            }

            Response.Redirect("HomePage.aspx");


        }
    }
}