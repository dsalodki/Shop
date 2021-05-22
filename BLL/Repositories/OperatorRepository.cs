using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Utility;
using DAL.Models;
using Operator = BLL.Models.Operator;

namespace BLL
{
    public class OperatorRepository : IOperatorRepository
    {
        private OracleDBContext _context;
        public OperatorRepository(OracleDBContext context)
        {
            _context = context;
        }

        public Operator SignIn(string userName, string password)
        {
            var user  = _context.Operators.FirstOrDefault(x => x.Name == userName && x.Pwd == password);
            return user == null ? null : new Operator(user.Id, user.Name, user.Pwd);
        }

        public IEnumerable<Operator> GetAll()
        {
            return _context.Operators.Select(x => new Operator(x.Id, x.Name, x.Pwd));
        }

        public bool Exists(string userName)
        {
            return _context.Operators.Any(x => x.Name == userName);
        }

        public void Create(string userName, string password)
        {
            _context.Operators.Add(new DAL.Models.Operator()
            {
                Name = userName,
                Pwd = password
                //Pwd = PasswordGenerator.GeneratePwd()
            });
            _context.SaveChanges();
        }

        public bool Remove(decimal id)
        {
            var user = _context.Operators.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return false;
            _context.Operators.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
