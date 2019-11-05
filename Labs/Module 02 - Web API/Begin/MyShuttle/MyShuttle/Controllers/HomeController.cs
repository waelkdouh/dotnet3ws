using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShuttle.Web.Models;
using MyShuttle.Model;
using MyShuttle.Data;


namespace MyShuttle.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICarrierRepository _carrierRepository;

        public HomeController(ICarrierRepository carrierRepository)
        {
            _carrierRepository = carrierRepository;
        }


        public IActionResult Index()
        {
            var model = new MyShuttleViewModel()
            {
                MainMessage = "The Ultimate B2B Shuttle Service Solution"
            };
            return View(model);
        }

        [HttpPost]
        public async Task<int> Post([FromBody]Carrier carrier)
        {
            return await _carrierRepository.AddAsync(carrier);
        }

    }
}