namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        public int ProductID { get; set; }
        public int LocationID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}