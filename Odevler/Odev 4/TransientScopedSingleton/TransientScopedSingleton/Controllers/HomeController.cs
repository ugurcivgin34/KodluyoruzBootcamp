using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TransientScopedSingleton.Models;

namespace TransientScopedSingleton.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransient _transientService1;
        private readonly ITransient _transientService2;
        private readonly IScoped _scoped1;
        private readonly IScoped _scoped2;
        private readonly ISingleton _singleton1;
        private readonly ISingleton _singleton2;

        public HomeController(ILogger<HomeController> logger, ITransient transientService1, ITransient transientService2,
            IScoped scoped1,IScoped scoped2,ISingleton singleton1,ISingleton singleton2)
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }

        public IActionResult Index()
        {
            ViewBag.TransientService1=_transientService1.GetOperation();
            ViewBag.TransientService2=_transientService2.GetOperation();

            ViewBag.Scoped1 = _scoped1.GetOperation();
            ViewBag.Scoped2 = _scoped2.GetOperation();

            ViewBag.Singleton1 = _singleton1.GetOperation();
            ViewBag.Singleton2 = _singleton2.GetOperation();

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
