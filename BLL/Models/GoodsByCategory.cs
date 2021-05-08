using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class GoodsByCategory
    {
        public GoodsByCategory(GoodsCat x)
        {
            CatName = x.Name;
            Items = x.Goods.Select(y => new Goods(y));
        }

        public string CatName { get; set; }
        public IEnumerable<Goods> Items { get; set; }
        public class Goods
        {
            public Goods(Good y)
            {
                Name = y.Name;
                Val = y.Val;
                OldPrice = y.Price;
                if (y.Sale > 0)
                {
                    var p = y.Price / 5;
                    if (p > 50)
                        p = 50;

                    NewPrice = y.Price - p;
                }
            }

            public string Name { get; set; }
            public decimal Val { get; set; }
            public decimal OldPrice { get; set; }
            public decimal NewPrice { get; set; }
        }
    }
}
