using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KagoolTest.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using KagoolTest.Data;

namespace KagoolTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _clientFactory;

        private BeerService _beerService;


        public HomeController(IConfiguration configuration, ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _clientFactory = clientFactory;

            _beerService = new BeerService(configuration, logger, _clientFactory);
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Beer> model = new List<Beer>();
            model = await _beerService.GetProducts();          

            return View(model);
        }



        /// <summary>
        /// Displays a page where the beers can be filtered by ABV
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Filter()
        {
            List<Beer> model = new List<Beer>();
            model = await _beerService.GetProducts();
            ViewBag.selected = "asc";

            var order = Request.Query["order"];
            if (!string.IsNullOrEmpty(order) && order == "asc")
            {
                model = model.OrderBy(x => x.ABV).ToList();
            }
            else if (!string.IsNullOrEmpty(order) && order == "desc")
            {
                model = model.OrderByDescending(x => x.ABV).ToList();
                ViewBag.selected = "asc";
            }

            return View(model);
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
