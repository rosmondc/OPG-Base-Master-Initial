using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using opg_201910_interview.Models;
using System.Text.Json;
using Interfaces;

namespace opg_201910_interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly IFileService _fileHelper;

        public HomeController(IConfiguration config, ILogger<HomeController> logger,
            IFileService fileHelper)
        {
            _logger = logger;
            _config = config;
            _fileHelper = fileHelper;
        }

        public IActionResult Index()
        {
            var fileResults = JsonSerializer.Serialize(_fileHelper.ProcessOrderFile(_config));
            Console.WriteLine("Index");
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
