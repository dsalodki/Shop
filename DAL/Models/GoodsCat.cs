using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class GoodsCat
    {
        public GoodsCat()
        {
            Goods = new HashSet<Good>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
