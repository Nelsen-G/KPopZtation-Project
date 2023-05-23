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

        public bool CheckLogin(string email, string password)
        {
            bool loginSuccess = customerRepository.ValidateCredentials(email, password);

            return loginSuccess;
        }

        public string GetUserName(string email)
        {
            return customerRepository.GetUserNameByEmail(email);
        }

        public bool checkEmail(String email)
        {
            return customerRepository.checkCustomerEmail(email);
        }

    }
}