using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ClientController : Controller
    {
        private IClientRepository _repository;
        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var clients = _repository.GetAll();
            var viewModel = clients.Select(x=> new ClientViewModel(x.Id, x.Name));

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientViewModel model)
        {
            if (_repository.Exists(model.Name))
            {
                ViewBag.Error = "Такое имя уже существует";
                return View();
            }

            _repository.Create(model.Name);
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

        public IActionResult Edit(decimal id)
        {
            var client = _repository.Get(id);
            if (client == null)
            {
                return BadRequest();
            }
            return View(new ClientViewModel(client.Id, client.Name));
        }

        [HttpPost]
        public IActionResult Edit(ClientViewModel model)
        {
            if (_repository.Exists(model.Name))
            {
                ViewBag.Error = "такое имя уже существует";
                return View(model);
            }

            if (_repository.Rename(model.Id, model.Name))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "что-то пошло не так, обратитесь в поддержку";
            return View(model);
        }
    }
}
