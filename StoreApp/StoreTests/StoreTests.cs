using System;
using Xunit;
using StoreModels;

namespace StoreTests
{
    public class StoreTests
    {
        //Arrange
        private Customer customer = new Customer();
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
        [InlineData("Jacob5Gaughan", false)]
        [InlineData("Mike 12",  false)]
        public void IsName(string name, bool expected)
        {
            bool result = customer.IsValidName(name);

            Assert.Equal(expected, result);
        }
    }
}
