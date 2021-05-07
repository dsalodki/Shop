using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class GoodsCategoryController : Controller
    {
        private IGoodsCategoryRepo _repository;

        public GoodsCategoryController(IGoodsCategoryRepo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var categories = _repository.GetAll();
            var viewModel = categories.Select(x=>new GoodsCategoryViewModel(x.Id, x.Name));
            return View(viewModel);
        }

        public IActionResult Edit(decimal id)
        {
            var category = _repository.Get(id);
            return View(new GoodsCategoryViewModel(category.Id, category.Name));
        }

        [HttpPost]
        public IActionResult Edit(GoodsCategoryViewModel model)
        {
            if (_repository.Exists(model.Name))
            {
                ViewBag.Error = "Такое имя уже есть";
                return View(model);
            }

            if (_repository.Rename(model.Id, model.Name))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Произошла неизвестная ошибка, обратитесь в поддержку";
            return View(model);
        }

    }
}
