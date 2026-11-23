using Fiap.Web.Alunos.Data;
using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.Alunos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _databaseContext = DatabaseContext;
        }

        public IActionResult Index()
        {

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
