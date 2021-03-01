using System;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public override string ToString() => $"\t Customer ID: {this.CustomerId} \n\t Location ID: {this.LocationId} \n\t Date: {this.Date} \n\t Total: ${this.Total}";
    }
}