using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ProviderController : Controller
    {
        private IProviderRepo _repository;

        public ProviderController(IProviderRepo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var providers = _repository.GetAll();
            var viewModel = providers.Select(x => new ProviderViewModel(x));
            return View(viewModel);
        }

        public IActionResult Edit(decimal id)
        {
            var provider = _repository.Get(id);
            if (provider == null)
                return BadRequest();
            var viewModel = new ProviderViewModel(provider);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProviderViewModel model)
        {
            var provider = new Provider(model.Id, model.Name, model.Address, model.Phone);
            if (_repository.Update(provider))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Сохранить не удалось";
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(decimal id)
        {
            if (_repository.Remove(id))
            {
                return Ok();
            }

            return BadRequest();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProviderViewModel model)
        {
            var provider = new Provider(0, model.Name, model.Address, model.Phone);
            if (_repository.Create(provider))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Не удалось создать поставщика, возможно поля дублируются";
            return View(model);
        }
    }
}
