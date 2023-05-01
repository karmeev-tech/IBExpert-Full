using IBExpert.ViewModel;
using IBExpert.ViewModel.Debtor;
using Microsoft.AspNetCore.Mvc;

namespace IBExpert.Controllers
{
    public class DebtorController : Controller
    {
        DebtorItem _debtorItem;
        public DebtorController()
        {
            _debtorItem = new DebtorItem()
            {
                Name = "Владим Владимирович Путин",
                Status = "В работе"
            }; 
        }

        public async Task<IActionResult> Index(int? id)
        {
            DebtorViewModel viewModel = new DebtorViewModel()
            {
                Items = new List<DebtorItem> {  _debtorItem }
            };

            return View("/Index",viewModel);
        }
    }
}
