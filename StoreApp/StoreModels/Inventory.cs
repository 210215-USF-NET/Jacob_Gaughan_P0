using System;
using System.Text.RegularExpressions;
namespace StoreModels
{

    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Inventory
    {
        private int quantity;
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int Id { get; set; }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (!IsValidQuantity(value))
                {
                    throw new ArgumentOutOfRangeException("Quantity must be a positive number.");
                }
                quantity = value;
            }
        }
        public bool IsValidQuantity(int quantity)
        {
            if(quantity < 0)
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