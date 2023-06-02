using KPopZtation_Project.Handler;
using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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


        public void RegisterCustomer(string name, string email, string gender, string address, string password, out string errorMessage)
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
            else if (!customerHandler.checkEmail(email))
            {
                errorMessage = "Email is already used";
                return;
            }

            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(email);

            if (!match.Success)
            {
                errorMessage = "Email must contain @ and . at least once";
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


            customerHandler.HandleRegistration(name, email, gender, address, password);
        }


        public void UpdateCustomer(int id, string name, string email, string gender, string address, string password, out string errorMessage)
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


            string previousEmail = customerHandler.GetCustomerEmail(id);
            // Validate Email
            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "Email must be filled";
                return;
            }

            if (!email.Equals(previousEmail, StringComparison.OrdinalIgnoreCase))
            {
                // kalo diganti namanya, baru cek
                if (!customerHandler.checkEmail(email))
                {
                    errorMessage = "Email Name must be unique";
                    return;
                }

            }
            else
            {
                email = previousEmail;
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


            customerHandler.HandleUpdate(id, name, email, gender, address, password);

        }


    }
}