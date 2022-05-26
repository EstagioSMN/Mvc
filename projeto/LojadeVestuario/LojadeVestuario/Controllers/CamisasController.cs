using LojadeVestuario.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojadeVestuario.Controllers
{
    public class CamisasController : Controller
    {
        private readonly ICamisasRepository _camisasRepository;

        public CamisasController(ICamisasRepository camisasRepository)
        {
            _camisasRepository = camisasRepository;
        }

        public IActionResult List()
        {
            ViewData["Titulo"] = "Todas as Camisas";
            ViewData["Data"] = DateTime.Now;


            var Camisas = _camisasRepository.Camisas;
            var totalCamisas = Camisas.Count();

            ViewBag.Total = "Total de Camisas : ";
            ViewBag.TotalCamisas = totalCamisas;

            return View(Camisas);
        }
    }
}