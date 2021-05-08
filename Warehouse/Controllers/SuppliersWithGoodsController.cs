using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class SuppliersWithGoodsController : Controller
    {
        private ISuppliersWithGoodsRepository _repository;

        public SuppliersWithGoodsController(ISuppliersWithGoodsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var data = _repository.GetAll();
            var viewModel = data.Select(x => new SuppliersWithGoodsViewModel(x));
            return View(viewModel);
        }
    }
}
