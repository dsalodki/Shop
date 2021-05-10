using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class DecommLogsViewModel
    {
        public DecommLogsViewModel(DecommLog x)
        {
            GoodsName = x.GoodsName;
            Price = x.Price;
        }

        public decimal Price { get; set; }

        public string GoodsName { get; set; }
    }
}
