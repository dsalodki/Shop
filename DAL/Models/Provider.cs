using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Goods = new HashSet<Good>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Deleting { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
