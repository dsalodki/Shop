using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Good
    {
        public Good()
        {
            DecommLogs = new HashSet<DecommLog>();
        }

        public decimal Id { get; set; }
        public string Idx { get; set; }
        public string Name { get; set; }
        public decimal GoodsCatId { get; set; }
        public decimal DimensionId { get; set; }
        public decimal Val { get; set; }
        public decimal ValDelivered { get; set; }
        public decimal Price { get; set; }
        public decimal? Weight { get; set; }
        public DateTime Delivery { get; set; }
        public decimal ImpPeriod { get; set; }
        public decimal? ImpTime { get; set; }
        public decimal? ProviderId { get; set; }
        public decimal Decommissioned { get; set; }
        public decimal Sale { get; set; }

        public virtual Dimension Dimension { get; set; }
        public virtual GoodsCat GoodsCat { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<DecommLog> DecommLogs { get; set; }
    }
}
