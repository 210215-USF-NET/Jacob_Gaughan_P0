using System;
using System.Text.RegularExpressions;

namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        private string customerName;
        private string customerEmail;
        public string CustomerName
        { 
            get{
                return customerName;
            }
            set{
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentNullException("Customer name can't be empty or null.");
                }
                else if (!IsValidName(value)) {
                    throw new Exception("Customer name can't have numbers in it.");
                }
                customerName = value;
            }
        }

        public string CustomerEmail {
            get{
                return customerEmail;
            }
            set{
                if (IsEmptyOrNull(value))
                {
                    throw new ArgumentNullException("Customer email can't be empty or null.");
                }
                else if (!IsValidEmail(value)) {
                    throw new Exception("Must be a valid email address.");
                }
                customerEmail = value;
            }
        }

        public PrevOrders PrevOrders { get; set; }
        //TODO: add more properties to identify the customer

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
    }
}