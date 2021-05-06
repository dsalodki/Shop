using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class DecommLog
    {
        public decimal Id { get; set; }
        public decimal GoodsId { get; set; }
        public DateTime LogDate { get; set; }
        public decimal Val { get; set; }
        public decimal Price { get; set; }

        public virtual Good Goods { get; set; }
    }
}
