using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class OrdersList
    {
        public decimal OrdersId { get; set; }
        public decimal GoodsId { get; set; }
        public decimal Val { get; set; }
        public decimal Price { get; set; }

        public virtual Good Goods { get; set; }
        public virtual Order Orders { get; set; }
    }
}
