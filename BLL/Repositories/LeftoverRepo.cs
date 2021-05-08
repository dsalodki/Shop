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
    public class LeftoverRepo : ILeftoverRepo
    {
        private OracleDBContext _context;

        public LeftoverRepo(OracleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Leftovers> Get(decimal minVal)
        {
            var db = _context.Goods.Where(x => x.Val <= minVal);
            return db.Select(x => new Leftovers(x.Name, x.Val));
        }
    }
}
