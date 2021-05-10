using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DecommLog
    {
        private DAL.Models.DecommLog x;

        public DecommLog(DAL.Models.DecommLog x)
        {
            Id = x.Id;
            Price = x.Price;
            GoodsName = x.Goods.Name;
        }

        public string GoodsName { get; set; }

        public decimal Price { get; set; }

        public decimal Id { get; set; }
    }
}
