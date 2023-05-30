using Client.MVC.IBExpert.Models;
using Client.MVC.IBExpert.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Client.MVC.IBExpert.Controllers
{
    public class DebtorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
