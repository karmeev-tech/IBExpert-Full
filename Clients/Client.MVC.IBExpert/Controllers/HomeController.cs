using Client.MVC.IBExpert.Models;
using Client.MVC.IBExpert.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.MVC.IBExpert.Controllers
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

        public IActionResult Debtor()
        {
            DebtorViewModel viewModel = new DebtorViewModel()
            {
                Items = new List<DebtorItem> {
                    new DebtorItem() {
                        Name = "Владим Владимирович Путин",
                        Status = "В работе" }
                }
            };
            return View("../Debtor/Index", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}