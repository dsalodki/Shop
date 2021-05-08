using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using BLL.Models;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class GoodsController : Controller
    {
        private IGoodsRepository _repository;
        public GoodsController(IGoodsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var goods = _repository.GetAll();

            var viewModel = goods.Select(x=>new GoodsViewModel(x));

            return View(viewModel);
        }

        public IActionResult Edit(decimal id)
        {
            ViewData["GoodsCategories"] = _repository.GetGoodsCategories();
            ViewData["Dimensions"] = _repository.GetDimensions();
            var providers = _repository.GetProviders().ToList();
            providers.Insert(0, new Item(null, "Выберите поставщика или оставьте пустым"));
            ViewData["Providers"] = providers;

            var goods = _repository.Get(id);
            if (goods == null)
                return BadRequest();
            return View(new GoodsViewModel(goods));
        }

        [HttpPost]
        public IActionResult Edit(GoodsViewModel model)
        {
            var goods = new Goods(model.Id, model.Idx, model.Name, model.GoodsCatId, model.DimensionId, model.ProviderId, model.Val, model.ValDelivered, model.Price, 
                model.Delivery, model.ImpPeriod, model.ImpTime, model.Weight, null, null, null, 0, 0);
            if (_repository.Update(goods))
            {
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        public IActionResult Create()
        {
            ViewData["GoodsCategories"] = _repository.GetGoodsCategories();
            ViewData["Dimensions"] = _repository.GetDimensions();
            var providers = _repository.GetProviders().ToList();
            providers.Insert(0, new Item(null, "Выберите поставщика или оставьте пустым"));
            ViewData["Providers"] = providers;
            return View();
        }

        [HttpPost]
        public IActionResult Create(GoodsViewModel model)
        {
            var goods = new Goods(0, model.Idx, model.Name, model.GoodsCatId, model.DimensionId, model.ProviderId,
                model.Val, model.ValDelivered, model.Price, model.Delivery,
                model.ImpPeriod, model.ImpTime, model.Weight, null, null, null, 0, 0);
            _repository.Create(goods);
            return RedirectToAction("Index");
        }
    }
}
