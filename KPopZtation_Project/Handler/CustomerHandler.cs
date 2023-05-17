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

        public void HandleRegistration(string name, string email, string gender, string address, string password, out string errorMessage)
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
            else if (!customerRepository.checkCustomerEmail(email))
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

            // If all validations pass, call the repository method to create the customer
            customerRepository.createCustomer(name, email, password, gender, address);
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

        public bool CheckLogin(string email, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "Email must be filled";
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Password must be filled";
                return false;
            }


            bool loginSuccess = customerRepository.ValidateCredentials(email, password);

            if (!loginSuccess)
            {
                errorMessage = "Invalid email or password";
            }

            return loginSuccess;
        }

        public string GetUserName(string email)
        {
            return customerRepository.GetUserNameByEmail(email);
        }
    }
}