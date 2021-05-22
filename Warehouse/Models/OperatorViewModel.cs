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

        public OperatorViewModel(decimal id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public decimal Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
