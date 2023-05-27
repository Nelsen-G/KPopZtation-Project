using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Factory
{
    public class CustomerFactory
    {
        
        public Customer addCustomer(String name, String email, String password, String gender, String address)
        {
            Customer newCustomer = new Customer();
            newCustomer.CustomerName = name;
            newCustomer.CustomerEmail = email;
            newCustomer.CustomerPassword = password;
            newCustomer.CustomerGender = gender;
            newCustomer.CustomerAddress = address;
            newCustomer.CustomerRole = "cust";

            return newCustomer;
        }
    }
}