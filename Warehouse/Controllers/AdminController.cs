using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IOperatorRepository _repository;

        public AdminController(IOperatorRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var operators = _repository.GetAll();
            var viewModel = operators.Select(x => new OperatorViewModel(x.Id, x.UserName, x.Passsword));

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OperatorViewModel model)
        {
            // check if exists
            if (_repository.Exists(model.UserName))
            {
                ViewBag.Error = "уже существует";
                return View();
            }
            // create
            _repository.Create(model.UserName, model.Password);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(decimal id)
        {
            if (_repository.Remove(id))
            {
                return new JsonResult(Ok());
            }

            return new JsonResult(BadRequest());
        }
    }
}
