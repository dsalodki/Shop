using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class LeftoversController : Controller
    {
        private ILeftoverRepo _repository;

        public LeftoversController(ILeftoverRepo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(decimal minVal)
        {
            var leftovers = _repository.Get(minVal);

            var viewModel = new LeftoversViewModel();
            viewModel.MinVal = minVal;
            viewModel.Leftovers = leftovers.Select(x => new Leftovers(x));
            return View(viewModel);
        }
    }
}
