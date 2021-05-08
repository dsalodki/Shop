using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Provider
    {
        public Provider(decimal id, string name, string address, string phone)
        {
            Phone = phone;
            Address = address;
            Name = name;
            Id = id;
        }

        public Provider(DAL.Models.Provider x)
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
