using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mvc1.Models;

namespace mvc1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        private string message;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRepository repository, IConfiguration config)
        {
            _logger = logger;
            _repository = repository;
            message = $"Docker -  ({config["HOSTNAME"]})";
        }

        public IActionResult Index()
        {
            ViewBag.Message = message;
            return View(_repository.Produtos);
        }
    }
}
