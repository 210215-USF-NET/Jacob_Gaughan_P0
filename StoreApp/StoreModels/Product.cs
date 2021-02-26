namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        public Location Location { get; set; }
        public int ProductID { get; set; }
        public int LocationID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}