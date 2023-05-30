using Client.MVC.IBExpert.Models;

namespace Client.MVC.IBExpert.ViewModels
{
    public class DebtorViewModel
    {
        public IEnumerable<DebtorItem> Items { get; set; } = new List<DebtorItem>()
        {
        new DebtorItem()
        {
            Name = "Name",
            Status = "Status"
        }
        };
    }
}
