using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDecommLogRepo
    {
        IEnumerable<DecommLog> GetAll();
        void Sync();
    }
}
