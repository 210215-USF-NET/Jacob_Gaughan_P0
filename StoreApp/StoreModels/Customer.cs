using System;
using System.Text.RegularExpressions;

namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        private string customerLastName;
        private string customerFirstName;
        private string customerEmail;
        private string prevOrders;
        private int customerID;

        public int CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
                value++;
            }
        }
        public string CustomerFirstName
        {
            get
            {
                return customerFirstName;
            }
            set
            {
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentNullException("Customer name can't be empty or null.");
                }
                else if (!IsValidName(value))
                {
                    throw new Exception("Customer name can't have numbers in it.");
                }
                customerFirstName = value;
            }
        }

        public string CustomerLastName
        {
            get
            {
                return customerLastName;
            }
            set
            {
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentNullException("Customer name can't be empty or null.");
                }
                else if (!IsValidName(value))
                {
                    throw new Exception("Customer name can't have numbers in it.");
                }
                customerLastName = value;
            }
        }

        public string CustomerEmail
        {
            get
            {
                return customerEmail;
            }
            set
            {
                if (IsEmptyOrNull(value))
                {
                    throw new ArgumentNullException("Customer email can't be empty or null.");
                }
                else if (!IsValidEmail(value))
                {
                    throw new Exception("Must be a valid email address.");
                }

                customerEmail = value;
            }
        }

        public string PrevOrders {
            get
            {
                return prevOrders;
            }
            set
            {
                prevOrders = value;
            }
        }

        public bool IsEmptyOrNull(string str)
        {
            //check to see if email has the required characters
            if (str == null || str.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsValidName(string name)
        {
            //check to see if name contains numbers
            if (Regex.IsMatch(name, ".*\\d+.*"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsValidEmail(string email)
        {
            //check to see if email has the required characters
            if (Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString() => $"Customer Details: \n\t Name: {this.CustomerFirstName} \n\t Email: {this.CustomerEmail}";
    }
}