using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Factory
{
    public class CustomerFactory
    {
        
        public static Customer addCustomer(String name, String email, String gender, String address, String password)
        {
            Customer newCustomer = new Customer();
            newCustomer.CustomerName = name;
            newCustomer.CustomerEmail = email;
            newCustomer.CustomerGender = gender;
            newCustomer.CustomerAddress = address;
            newCustomer.CustomerPassword = password;

            return newCustomer;
        }
    }
}