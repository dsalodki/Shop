using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IGoodsRepository
    {
        IEnumerable<Goods> GetAll();
        Goods Get(decimal id);
        IEnumerable<Item> GetGoodsCategories();
        IEnumerable<Item> GetDimensions();
        IEnumerable<Item> GetProviders();
        bool Update(Goods goods);
    }
}
