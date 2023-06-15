namespace Arbitr.API.Api
{
    public class SendArbitrRequest
    {
        public string Name { get; set; } = null!;
        public string Organization { get; set; } = null!;
        public string GosReg { get; set; } = null!;
        public string Insurance { get; set; } = null!;
        public string AboutInsurance { get; set; } = null!;
        public string ExtInsurance { get; set; } = null!;
        public string SecondGosReg { get; set; } = null!;
        public string SecondDocInsurance { get; set; } = null!;
        public string DeliverCorrespondAd { get; set; } = null!;
    }
}
