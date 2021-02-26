using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public int? Customer { get; set; }
        public int? Location { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }
    }
}
