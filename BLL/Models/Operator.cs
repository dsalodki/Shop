using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Operator
    {
        public Operator(decimal id, string name, string pwd)
        {
            Id = id;
            UserName = name;
            Passsword = pwd;
        }

        public decimal Id { get; set; }
        public string UserName { get; set; }
        public string Passsword { get; set; }
    }
}
