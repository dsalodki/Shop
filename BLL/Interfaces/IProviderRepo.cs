using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IProviderRepo
    {
        IEnumerable<Provider> GetAll();
        Provider Get(decimal id);
        bool Update(Provider provider);
        bool Remove(decimal id);
        bool Create(Provider provider);
    }
}
