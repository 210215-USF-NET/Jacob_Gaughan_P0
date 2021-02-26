using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Items = new HashSet<Item>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
