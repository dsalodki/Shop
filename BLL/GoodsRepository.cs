using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL.Models;

namespace BLL
{
    public class GoodsRepository : IGoodsRepository
    {
        private OracleDBContext _context;
        public GoodsRepository(OracleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Goods> GetAll()
        {
            //return _context.Goods.Select(x => new Goods(x.Id, x.Name, x.GoodsCatId, x.DimensionId, x.ProviderId,  x.Weight));
            throw new NotImplementedException();
        }
    }
}
