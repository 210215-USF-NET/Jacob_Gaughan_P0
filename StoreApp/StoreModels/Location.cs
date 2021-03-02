using System;
namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        private string state;
        private string zipcode;
        public string Address { get; set; }
        public string City { get; set; }
        public int Id { get; set; }

        public override string ToString() => $"{this.Address} {this.City}, {this.State} ({this.Zipcode})";
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (!IsValidState(value))
                {
                    throw new Exception("Location state be longer than 2 characters. (carrect example: NY)");
                }
                state = value;
            }
        }
        public string Zipcode
        {
            get
            {
                return zipcode;
            }
            set
            {
                if (!IsValidZipcode(value))
                {
                    throw new Exception("Location zipcode be longer than 5 numbers. (carrect example: 12345)");
                }
                zipcode = value;
            }
        }
        public bool IsValidState(string state)
        {
            if(state.Length > 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsValidZipcode(string zipcode)
        {
            if(zipcode.Length > 5)
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