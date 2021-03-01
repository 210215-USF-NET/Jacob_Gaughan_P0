namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public int Id { get; set; }

        public override string ToString() => $"{this.Address} {this.City}, {this.State} ({this.Zipcode})";
    }
}