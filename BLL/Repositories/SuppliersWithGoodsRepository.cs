using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL.Models;

namespace BLL.Repositories
{
    public class SuppliersWithGoodsRepository : ISuppliersWithGoodsRepository
    {
        private OracleDBContext _context;

        public SuppliersWithGoodsRepository(OracleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<SuppliersWithGoods> GetAll()
        {
            var data = _context.Providers.Where(x => x.Deleting == 0 && x.Goods.Count > 0)
                .Select(x => new SuppliersWithGoods()
                {
                    SupplierName = x.Name,
                    OwnGoods = x.Goods.Select(y => new SuppliersWithGoods.Goods()
                    {
                        Name = y.Name,
                        Val = y.Val
                    })
                });
            return data;
        }
    }
}
