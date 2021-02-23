using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        private object locations = new List<Location>() {
                new Location(){ City = "Hays", State="KS"},
                new Location(){ City = "Durango", State="CO"},
                new Location(){ City = "Charleston", State="SC"}
            };
        public string City { get; set; }
        public string State { get; set; }
        public string LocationName { get; set; }
        //TODO: add some property for the location inventory
    }
}