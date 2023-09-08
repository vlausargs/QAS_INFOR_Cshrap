
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopShipmentPackageDimensions
    {
        decimal Height { get; }
        decimal Length { get; }
        string UOM { get; }
        decimal Width { get; }
    }
    public class FreightRateShopShipmentPackageDimensions : IFreightRateShopShipmentPackageDimensions
    {
        public FreightRateShopShipmentPackageDimensions(string uOM, decimal length, decimal width, decimal height)
        {
            UOM = uOM;
            Length = length;
            Width = width;
            Height = height;
        }

      public string UOM { get; }
      public decimal Length { get; }
      public decimal Width { get; }
      public decimal Height { get; }
    }
}
