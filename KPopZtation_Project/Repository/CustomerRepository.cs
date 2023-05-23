﻿using KPopZtation_Project.Factory;
using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Repository
{
    public class CustomerRepository
    {

        dbKPopEntities db = dbSingleton.getInstance();

        public Customer createCustomer(String name, String email, String password, String gender, String address)
        {
            CustomerFactory cf = new CustomerFactory();

            Customer newCustomer = cf.addCustomer(name, email, password, gender, address); // This follows the ERD order

            db.Customers.Add(newCustomer);
            db.SaveChanges();

      

            return newCustomer;
        }

        public bool checkCustomerEmail(String email)
        {
            return !db.Customers.Any(c => c.CustomerEmail == email);
        }


        public bool ValidateCredentials(string email, string password)
        {
            Customer c = (from cs in db.Customers where cs.CustomerEmail == email && cs.CustomerPassword == password select cs).FirstOrDefault();

            if (c != null)
            {
                return true;
            }

            return false;
        }

        public string GetUserNameByEmail(string email)
        {
            return db.Customers.FirstOrDefault(c => c.CustomerEmail == email)?.CustomerName;
        }

        public int GetCustomerID(HttpContext context)
        {
            if (context.Session["user"] != null && context.Session["user"].ToString() == "Customer")
            {
               
                if (context.Session["customerID"] != null && int.TryParse(context.Session["customerID"].ToString(), out int customerID))
                {
                  
                    return customerID;
                }

                return 0;
            }

            return 0;
     
        }

    }
}