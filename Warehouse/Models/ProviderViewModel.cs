using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ProviderViewModel
    {
        public ProviderViewModel()
        {
        }

        public ProviderViewModel(Provider x)
        {
            Id = x.Id;
            Name = x.Name;
            Address = x.Address;
            Phone = x.Phone;
        }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public decimal Id { get; set; }
    }
}
