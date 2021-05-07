using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class OperatorViewModel
    {
        public OperatorViewModel()
        {
        }

        public OperatorViewModel(decimal id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public decimal Id { get; set; }
        public string UserName { get; set; }
    }
}
