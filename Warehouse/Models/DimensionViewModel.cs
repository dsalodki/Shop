using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class DimensionViewModel
    {
        public DimensionViewModel()
        {
        }

        public DimensionViewModel(Dimension x)
        {
            Id = x.Id;
            Name = x.Name;
        }

        public string Name { get; set; }

        public decimal Id { get; set; }
    }
}
