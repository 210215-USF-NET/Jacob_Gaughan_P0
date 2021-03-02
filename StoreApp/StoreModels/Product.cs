using System;
using System.Text.RegularExpressions;

namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        private decimal productPrice;
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? Id { get; set; }
        public decimal ProductPrice
        {
            get
            {
                return productPrice;
            }
            set
            {
                if(!IsValidPrice(value))
                {
                    throw new ArgumentOutOfRangeException("Price of a product must be a positive number.");
                }
                productPrice = value;
            }
        }
        public bool IsValidPrice(decimal price)
        {
            //check price to make sure it is not negative
            if (price < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}