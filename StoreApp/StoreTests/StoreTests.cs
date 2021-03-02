using System;
using Xunit;
using StoreModels;

namespace StoreTests
{
    public class StoreTests
    {
        //Arrange
        private Customer customer = new Customer();
        private Inventory inventory = new Inventory();
        private Location location = new Location();
        private Order order = new Order();
        private Product product = new Product();
        
        [Theory]
        [InlineData("testing123@revature.net", true)]
        [InlineData("testing123@revature", false)]
        [InlineData("testing123revature.net",  false)]
        public void IsEmail(string email, bool expected)
        {
            bool result = customer.IsValidEmail(email);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("John Doe", true)]
        [InlineData("JohnDoe 12", false)]
        [InlineData("Jo5hn Doe", false)]
        public void IsName(string name, bool expected)
        {
            bool result = customer.IsValidName(name);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(19.99, true)]
        [InlineData(10234.32, true)]
        [InlineData(-10.25, false)]
        public void IsValidPrice(decimal price, bool expected)
        {
            bool result = product.IsValidPrice(price);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("NY", true)]
        [InlineData("KSD", false)]
        [InlineData("Kansas", false)]
        public void IsValidState(string state, bool expected)
        {
            bool result = location.IsValidState(state);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("67601", true)]
        [InlineData("123456", false)]
        [InlineData("951230234", false)]
        public void IsValidZipcode(string zipcode, bool expected)
        {
            bool result = location.IsValidZipcode(zipcode);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(-1, false)]
        [InlineData(-25, false)]
        public void IsValidQuantity(int quantity, bool expected)
        {
            bool result = inventory.IsValidQuantity(quantity);

            Assert.Equal(expected, result);
        }
    }
}
