namespace CSI.BusInterface.ESBExtWhse
{
    public interface IExternalWarehouse
    {
        string ConvertExternalWhseToLocalWhse(string WareHouse);
    }

    public class ExternalWarehouse : IExternalWarehouse
    {
        public string ConvertExternalWhseToLocalWhse(string WareHouse)
        {
            return WareHouse?.Substring((int)(WareHouse?.LastIndexOf("~") + 1));
        }
    }
}
