
namespace CSI.Logistics.Customer
{
    public interface IFreightRateShopEquipmentTypes
    {
        string EquipmentType { get; }
    }
    public class FreightRateShopEquipmentTypes : IFreightRateShopEquipmentTypes
    {

        public string EquipmentType { get; }

        public FreightRateShopEquipmentTypes(string equipmenttype)
        {
            EquipmentType = equipmenttype;
        }
    }
}
