namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Orders
    {
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public double Total { get; set; }
        public string Date { get; set; }
        public int? Id { get; set; }
        public override string ToString() => $"\n\t Location: {this.Location} \n\t Date: {this.Date} \n\t Total: {this.Total}";
    }
}