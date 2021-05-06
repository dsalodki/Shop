using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Order
    {
        public decimal Id { get; set; }
        public decimal ClientsId { get; set; }
        public DateTime OrdDate { get; set; }
        public decimal Complete { get; set; }

        public virtual Client Clients { get; set; }
    }
}
