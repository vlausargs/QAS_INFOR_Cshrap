
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopModes
    {
        string Modes { get; }
    }
    public class FreightRateShopModes : IFreightRateShopModes
    {
        public string Modes { get; }

        public FreightRateShopModes(string mode)
        {
            Modes = mode;
        }


    }
}
