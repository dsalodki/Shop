using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Dimension
    {
        public Dimension()
        {
            Goods = new HashSet<Good>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
