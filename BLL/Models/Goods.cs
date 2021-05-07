using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Goods
    {
        public Goods(decimal id, string idx, string name, decimal goodsCatId, decimal dimensionId, decimal? providerId, decimal val, decimal valDelivered, decimal price, DateTime delivery, decimal impPeriod, decimal? impTime, decimal? weight,
            string goodsCat, string dimension, string provider,
            decimal decommissioned, decimal sale)
        {
            Id = id;
            Idx = idx;
            Name = name;
            GoodsCatId = goodsCatId;
            DimensionId = dimensionId;
            ProviderId = providerId;
            Val = val;
            ValDelivered = valDelivered;
            Price = price;
            Delivery = delivery;
            ImpPeriod = impPeriod;
            ImpTime = impTime;
            Weight = weight;

            GoodsCat = goodsCat;
            Dimension = dimension;
            Provider = provider;

            Decommissioned = decommissioned;
            Sale = sale;
        }

        public decimal Sale { get; set; }
        public decimal Decommissioned { get; set; }

        public string Provider { get; set; }
        public string Dimension { get; set; }
        public string GoodsCat { get; set; }

        public decimal Id { get; set; }
        public string Idx { get; set; }
        public string Name { get; set; }
        public decimal GoodsCatId { get; set; }
        public decimal DimensionId { get; set; }
        public decimal? ProviderId { get; set; }
        public decimal Val { get; set; }
        public decimal ValDelivered { get; set; }
        public decimal Price { get; set; }
        public DateTime Delivery { get; set; }
        public decimal ImpPeriod { get; set; }
        public decimal? ImpTime { get; set; }
        public decimal? Weight { get; set; }
    }
}
