using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BLL.Interfaces;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class DecommLogController : Controller
    {
        private readonly IDecommLogRepo _repository;

        public DecommLogController(IDecommLogRepo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            _repository.Sync();
            var logs = _repository.GetAll();
            var viewModel = logs.Select(x => new DecommLogsViewModel(x));
            return View(viewModel);
        }
    }
}
