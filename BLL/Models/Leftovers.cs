using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Leftovers
    {
        public Leftovers(string name, decimal val)
        {
            Name = name;
            Val = val;
        }

        public string Name { get; set; }
        public decimal Val { get; set; }
    }
}
