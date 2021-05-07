using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IGoodsCategoryRepo
    {
        IEnumerable<GoodsCategory> GetAll();
        GoodsCategory Get(decimal id);
        bool Exists(string name);
        bool Rename(decimal id, string name);
    }
}
