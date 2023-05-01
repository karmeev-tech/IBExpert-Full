namespace IBExpert.ViewModel.Debtor
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
