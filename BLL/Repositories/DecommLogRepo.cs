using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using DecommLog = BLL.Models.DecommLog;

namespace BLL.Repositories
{
    public class DecommLogRepo : IDecommLogRepo
    {
        private readonly OracleDBContext _context;

        public DecommLogRepo(OracleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<DecommLog> GetAll()
        {
            // todo : may be use UTC
            return _context.DecommLogs.Where(x=>x.LogDate == DateTime.Today).Select(x=>new DecommLog(x));
        }

        public void Sync()
        {
            var conn = _context.Database.GetDbConnection();
                conn.Query("shop.create_decomm_log", commandType: CommandType.StoredProcedure);
                //var hours = conn.Query<double>("select shop.get_goods_exp_h(12) from dual", commandType:CommandType.Text).Single();
        }
    }
}
