using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            return _context.Goods.Select(x => 
                new Goods(x.Id, x.Idx, x.Name, x.GoodsCatId, x.DimensionId, x.ProviderId, x.Val, x.ValDelivered, x.Price, x.Delivery, x.ImpPeriod, x.ImpTime, x.Weight, x.GoodsCat.Name, x.Dimension.Name, x.Provider == null ? null : x.Provider.Name, x.Decommissioned, x.Sale));
        }

        public Goods Get(decimal id)
        {
            var goods = _context.Goods.FirstOrDefault(x => x.Id == id);
            if (goods == null)
                return null;
            return new Goods(goods.Id, goods.Idx, goods.Name, goods.GoodsCatId, goods.DimensionId, goods.ProviderId,
                goods.Val, goods.ValDelivered, goods.Price, goods.Delivery,
                goods.ImpPeriod, goods.ImpTime, goods.Weight, null, null, null, goods.Decommissioned, goods.Sale);
        }

        public IEnumerable<Item> GetGoodsCategories()
        {
            return _context.GoodsCats.Select(x => new Item(x.Id, x.Name));
        }

        public IEnumerable<Item> GetDimensions()
        {
            return _context.Dimensions.Select(x => new Item(x.Id, x.Name));
        }

        public IEnumerable<Item> GetProviders()
        {
            return _context.Providers.Where(x=>x.Deleting == 0).Select(x => new Item(x.Id, x.Name));
        }

        public bool Update(Goods goods)
        {
            var db = _context.Goods.FirstOrDefault(x => x.Id == goods.Id);
            if (db == null)
                return false;
            // init
            db.Idx = goods.Idx;
            db.Name = goods.Name;
            db.GoodsCatId = goods.GoodsCatId;
            db.DimensionId = goods.DimensionId;
            db.Val = goods.Val;
            db.ValDelivered = goods.ValDelivered;
            db.Price = goods.Price;
            db.Weight = goods.Weight;
            db.Delivery = goods.Delivery;
            db.ImpPeriod = goods.ImpPeriod;
            db.ImpTime = goods.ImpTime;
            db.ProviderId = goods.ProviderId;

            _context.SaveChanges();
            return true;
        }

        public void Create(Goods goods)
        {
            var db = new Good();
            // init
            db.Idx = goods.Idx;
            db.Name = goods.Name;
            db.GoodsCatId = goods.GoodsCatId;
            db.DimensionId = goods.DimensionId;
            db.Val = goods.Val;
            db.ValDelivered = goods.ValDelivered;
            db.Price = goods.Price;
            db.Weight = goods.Weight;
            db.Delivery = goods.Delivery;
            db.ImpPeriod = goods.ImpPeriod;
            db.ImpTime = goods.ImpTime;
            db.ProviderId = goods.ProviderId;

            _context.Add(db);
            _context.SaveChanges();
        }
    }
}
