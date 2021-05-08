using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SuppliersWithGoods
    {
        public string SupplierName { get; set; }
        public IEnumerable<Goods> OwnGoods { get; set; }

        public class Goods
        {
            public string Name { get; set; }
            public decimal Val { get; set; }
        }
    }


}
