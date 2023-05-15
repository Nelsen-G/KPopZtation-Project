using KPopZtation_Project.Factory;
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

    }
}