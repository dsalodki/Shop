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
    public class DimensionController : Controller
    {
        private IDimensionRepo _repository;

        public DimensionController(IDimensionRepo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var dimensions = _repository.GetAll();
            var viewModel = dimensions.Select(x => new DimensionViewModel(x));
            return View(viewModel);
        }

        public IActionResult Edit(decimal id)
        {
            var dimension = _repository.Get(id);
            if (dimension == null)
                return BadRequest();
            return View(new DimensionViewModel(dimension));
        }

        [HttpPost]
        public IActionResult Edit(DimensionViewModel model)
        {
            var dimension = new Dimension(model.Id, model.Name);
            if (_repository.Update(dimension))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Произошла ошибка, обратитесь в поддержку";
            return View(model);
        }
    }
}
