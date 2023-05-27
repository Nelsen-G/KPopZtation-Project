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

        public bool checkEmail(String email)
        {
            return customerRepository.checkCustomerEmail(email);
        }


        public string GetCustomerEmail(int id)
        {
            return customerRepository.SelectCustomerEmail(id);
        }




    }
}