using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDimensionRepo
    {
        IEnumerable<Dimension> GetAll();
        Dimension Get(decimal id);
        bool Update(Dimension dimension);
    }
}
