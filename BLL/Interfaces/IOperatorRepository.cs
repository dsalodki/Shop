using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IOperatorRepository
    {
        public Operator SignIn(string userName, string password);
        IEnumerable<Operator> GetAll();
        bool Exists(string userName);
        void Create(string userName, string password);
        bool Remove(decimal id);
    }
}
