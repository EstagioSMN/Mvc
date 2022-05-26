using LojadeVestuario.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojadeVestuario.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            TempData["Nome"] = "Caio";
            return View();
        }

        public IActionResult Categorias()
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