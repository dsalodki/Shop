using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories
{
    public class FileWithGoodsRepo : IFileWithGoodsRepo
    {
        private OracleDBContext _context;

        public FileWithGoodsRepo(OracleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<GoodsByCategory> GetAll()
        {
            return _context.GoodsCats.Include(x=>x.Goods).Where(x=>x.Goods.Count > 0).Select(x => new GoodsByCategory(x));
        }
    }
}
