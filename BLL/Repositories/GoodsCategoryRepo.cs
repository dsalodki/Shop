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
    public class GoodsCategoryRepo : IGoodsCategoryRepo
    {
        private OracleDBContext _context;

        public GoodsCategoryRepo(OracleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<GoodsCategory> GetAll()
        {
            var categories = _context.GoodsCats;
            return categories.Select(x => new GoodsCategory(x.Id, x.Name));
        }

        public GoodsCategory Get(decimal id)
        {
            var category = _context.GoodsCats.FirstOrDefault(x => x.Id == id);
            return category == null ? null : new GoodsCategory(category.Id, category.Name);
        }

        public bool Exists(string name)
        {
            return _context.GoodsCats.Any(x => x.Name == name);
        }

        public bool Rename(decimal id, string name)
        {
            var category = _context.GoodsCats.FirstOrDefault(x => x.Id == id);
            if (category == null)
                return false;
            category.Name = name;
            _context.SaveChanges();
            return true;
        }
    }
}
