
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentPickupDateTime
    {
        string Date { get; }
        string Time { get; }
    }
    public class FreightRateShopShipmentPickupDateTime : IFreightRateShopShipmentPickupDateTime
    {
        public string Date { get;  }
        public string Time { get; }

        public FreightRateShopShipmentPickupDateTime(string date, string time)
        {
            Date = date;
            Time = time;
        }
    }
}
