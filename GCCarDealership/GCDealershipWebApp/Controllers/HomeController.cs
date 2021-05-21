using GCDealershipWebApp.Models;
using GCDealershipWebApp.Service;
using GCDealershipWebApp.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GCDealershipWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly IDealerService _service;

        public HomeController(ILogger<HomeController> logger, IDealerService servcie)
        {
            _logger = logger;
            _service = servcie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Result()
        {
            var result = await _service.GetDealerData();
            return View(result);
        }

        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> SearchDealership(DealerSearch viewModel)
        {
            var results = await _service.SearchDealer(viewModel);
            return View(results);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
