using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;

namespace Warehouse.Models
{
    public class SuppliersWithGoodsViewModel
    {
        public SuppliersWithGoodsViewModel(SuppliersWithGoods x)
        {
            SupplierName = x.SupplierName;
            Items = x.OwnGoods.Select(y => new Goods(y.Name, y.Val));
        }

        public string SupplierName { get; set; }
        public IEnumerable<Goods> Items { get; set; }
        public class Goods
        {
            public Goods(string name, decimal val)
            {
                Name = name;
                Val = val;
            }

            public string Name { get; set; }
            public decimal Val { get; set; }
        }
    }
}
