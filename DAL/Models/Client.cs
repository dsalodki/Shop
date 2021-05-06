using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal Deleting { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
