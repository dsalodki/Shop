using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Dimension
    {
        public Dimension(decimal id, string name)
        {
            Id = id;
            Name = name;
        }

        public Dimension(DAL.Models.Dimension x)
        {
            Id = x.Id;
            Name = x.Name;
        }

        public string Name { get; set; }

        public decimal Id { get; set; }
    }
}
