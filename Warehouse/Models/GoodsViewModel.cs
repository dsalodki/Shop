using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class GoodsViewModel
    {
        public GoodsViewModel()
        {
        }

        public GoodsViewModel(Goods goods)
        {
            Id = goods.Id;
            Idx = goods.Idx;
            Name = goods.Name;
            GoodsCatId = goods.GoodsCatId;
            DimensionId = goods.DimensionId;
            ProviderId = goods.ProviderId;
            Val = goods.Val;
            ValDelivered = goods.ValDelivered;
            Price = goods.Price;
            Delivery = goods.Delivery;
            ImpPeriod = goods.ImpPeriod;
            ImpTime = goods.ImpTime;
            Weight = goods.Weight;

            GoodsCatName = goods.GoodsCat;
            DimensionName = goods.Dimension;
            ProviderName = goods.Provider;

            Decommissioned = goods.Decommissioned;
            Sale = goods.Sale;
        }

        public decimal Id { get; set; }
        public string Idx { get; set; }
        public string Name { get; set; }
        public decimal GoodsCatId { get; set; }
        public string GoodsCatName { get; set; }
        public decimal DimensionId { get; set; }
        public string DimensionName { get; set; }
        public decimal? ProviderId { get; set; }
        public string ProviderName { get; set; }
        public decimal Val { get; set; }
        public decimal ValDelivered { get; set; }
        public decimal Price { get; set; }
        public DateTime Delivery { get; set; }
        public decimal ImpPeriod { get; set; }
        public decimal? ImpTime { get; set; }
        public decimal? Weight { get; set; }
        public decimal Decommissioned { get; set; }
        public decimal Sale { get; set; }
    }
}
