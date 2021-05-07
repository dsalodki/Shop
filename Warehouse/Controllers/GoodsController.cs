using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;

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
            //var goods = _repository.GetAll();

            //var viewModel = goods.Select();

            return View();
        }
    }
}
