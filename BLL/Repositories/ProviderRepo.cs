using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Provider = BLL.Models.Provider;

namespace BLL.Repositories
{
    public class ProviderRepo : IProviderRepo
    {
        private OracleDBContext _context;

        public ProviderRepo(OracleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Provider> GetAll()
        {
            var db = _context.Providers.Where(x => x.Deleting == 0);
            return db.Select(x => new Provider(x));
        }

        public Provider Get(decimal id)
        {
            var db = _context.Providers.FirstOrDefault(x => x.Deleting == 0 && x.Id == id);
            return db == null ? null : new Provider(db);
        }

        public bool Update(Provider provider)
        {
            // check exists and not deleted
            var db = _context.Providers.FirstOrDefault(x => x.Deleting == 0 && x.Id == provider.Id);
            if (db == null)
                return false;

            db.Name = provider.Name;
            db.Address = provider.Address;
            db.Phone = provider.Phone;
            _context.SaveChanges();
            return true;
        }

        public bool Remove(decimal id)
        {
            var db = _context.Providers.FirstOrDefault(x => x.Deleting == 0 && x.Id == id);
            if (db == null)
                return false;
            db.Deleting = 1;
            _context.SaveChanges();
            return true;
        }

        public bool Create(Provider provider)
        {
            // check duplicating
            if (_context.Providers.Any(x => x.Name == provider.Name) ||
                _context.Providers.Any(x => x.Address == provider.Address) ||
                _context.Providers.Any(x => x.Phone == provider.Phone))
            {
                return false;
            }

            var db = new DAL.Models.Provider {Name = provider.Name, Address = provider.Address, Phone = provider.Phone};
            _context.Providers.Add(db);
            _context.SaveChanges();
            return true;
        }
    }
}
