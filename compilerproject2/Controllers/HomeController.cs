using compilerproject2.Models;
using Controllers.RunScanner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace compilerproject2.Controllers
{
    public class HomeController : Controller
    {
        private const string V = "output.txt";
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult ScannOrParse(string Code,int operation)
        {

            if (operation == 1) {
                ViewBag.home = false;
                ViewBag.Code = Code;
                ViewBag.output = RunScanner.RUN(Code);
                Console.WriteLine("Controller");
                foreach(var token in ViewBag.output)
                {
                    Console.WriteLine(token);
                }
                ViewBag.operation = operation;
                return View();
            }
            return View();
        }
        public IActionResult Upload_file(string Code, int operation)
        {
            if (operation == 1)
            {
                ViewBag.home = false;
                ViewBag.Code = Code;
                ViewBag.output = RunScanner.RUN(Code);
                ViewBag.operation = operation;
                return View();
            }
            return View();
        }

        public IActionResult Index()
        {
            ViewBag.home = true;
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
        public IActionResult Scan(string code)
        {
            //var output = RunScanner.RUN(code);
            //ViewBag.output = output;
            return View();
        }
    }
}
