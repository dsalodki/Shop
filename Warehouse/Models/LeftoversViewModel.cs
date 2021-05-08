using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class LeftoversViewModel
    {
        public IEnumerable<Leftovers> Leftovers { get; set; }
        public decimal MinVal { get; set; }
    }

    public class Leftovers
    {
        public Leftovers(BLL.Models.Leftovers x)
        {
            Name = x.Name;
            Val = x.Val;
        }

        public string Name { get; set; }
        public decimal Val { get; set; }
    }
}
