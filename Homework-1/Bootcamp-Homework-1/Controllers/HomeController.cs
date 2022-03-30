using Bootcamp_Homework_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp_Homework_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sample(DataViewModel model)
        {
            var people = new ResponseViewModel
            {
               Data="Giriş işlemi başarılı",
               Success=true,
               Error="Null"

            };
            if (!ModelState.IsValid)

            //modalstate hata mesajlarını gösterecek.
            {
                var people2 = new ResponseViewModel
                {
                    Data = "Null",
                    Success = false,
                    Error = "Hatalı giriş"

                };

                ViewData["message"] = "<div class='alert alert-danger col-sm-6 ml-3 mt-5'>" + "Data :" + people2.Data + ", Success: " + people2.Success + ", Error: " + people2.Error + "</div>";



                return View();
            }
            ViewData["message"] = "<div class='alert alert-success col-sm-6 ml-3 mt-5'>" + "Data :" + people.Data + ", Success: " + people.Success + ", Error: " + people.Error + "</div>";
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Sample()
        {
            
            
            var customer = new DataViewModel
            {

            };
          
            return View(customer);
        }
    }
}
