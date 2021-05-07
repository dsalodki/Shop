using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();
        bool Exists(string name);
        void Create(string name);
        bool Remove(decimal id);
        Client Get(decimal id);
        bool Rename(decimal id, string name);
    }
}
