using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Client = BLL.Models.Client;

namespace BLL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private OracleDBContext _context;

        public ClientRepository(OracleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            var clients = _context.Clients.Where(x => x.Deleting == 0);
            return clients.Select(x => new Client(x.Id, x.Name));
        }

        public bool Exists(string name)
        {
            return _context.Clients.Any(x => x.Name == name);
        }

        public void Create(string name)
        {
            _context.Clients.Add(new DAL.Models.Client()
            {
                Name = name
            });
            _context.SaveChanges();
        }

        public bool Remove(decimal id)
        {
            var user = _context.Clients.FirstOrDefault(x => x.Id == id && x.Deleting == 0);
            if (user == null)
                return false;

            user.Deleting = 1;
            _context.SaveChanges();
            return true;
        }

        public Client Get(decimal id)
        {
            var user = _context.Clients.FirstOrDefault(x => x.Deleting == 0 && x.Id == id);

            return user == null ? null : new Client(user.Id, user.Name);
        }

        public bool Rename(decimal id, string name)
        {
            var user = _context.Clients.FirstOrDefault(x => x.Deleting == 0 && x.Id == id);
            if (user == null)
            {
                return false;
            }

            user.Name = name;
            _context.SaveChanges();
            return true;
        }
    }
}
