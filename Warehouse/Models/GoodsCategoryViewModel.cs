using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class GoodsCategoryViewModel
    {
        public GoodsCategoryViewModel()
        {
        }

        public GoodsCategoryViewModel(decimal id, string name)
        {
            Id = id;
            Name = name;
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
    }
}
