namespace DroneStore.Web.Models.Currency
{
    public class ExchangeRateViewModel
    {
        private string _usdRubRate;
        public string UsdRubRate
        {
            get => _usdRubRate ?? "0";
            set => _usdRubRate = value;
        }

        private string _eurRubRate;
        public string EurRubRate
        {
            get => _eurRubRate ?? "0";
            set => _eurRubRate = value;
        }
    }
}
