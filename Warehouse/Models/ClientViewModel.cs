using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ClientViewModel
    {
        public ClientViewModel()
        {
        }

        public ClientViewModel(decimal id, string name)
        {
            Id = id;
            Name = name;
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
    }
}
