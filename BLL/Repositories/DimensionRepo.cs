using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Dimension = BLL.Models.Dimension;

namespace BLL.Repositories
{
    public class DimensionRepo : IDimensionRepo
    {
        private OracleDBContext _context;

        public DimensionRepo(OracleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Dimension> GetAll()
        {
            var dimensions = _context.Dimensions;
            return dimensions.Select(x => new Dimension(x));
        }

        public Dimension Get(decimal id)
        {
            var dimension = _context.Dimensions.FirstOrDefault(x => x.Id == id);
            return dimension == null ? null : new Dimension(dimension);
        }

        public bool Update(Dimension dimension)
        {
            // exists
            if (_context.Dimensions.Any(x => x.Name == dimension.Name))
            {
                return false;
            }

            var db = _context.Dimensions.FirstOrDefault(x => x.Id == dimension.Id);
            if (db == null)
                return false;

            db.Name = dimension.Name;
            _context.SaveChanges();
            return true;
        }
    }
}
