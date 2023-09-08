//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateLocationForExternalWarehouseFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ValidateLocationForExternalWarehouseFactory
    {
        public IValidateLocationForExternalWarehouse Create(IApplicationDB appDB)
        {
            var _ValidateLocationForExternalWarehouse = new ValidateLocationForExternalWarehouse(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateLocationForExternalWarehouseExt = timerfactory.Create<IValidateLocationForExternalWarehouse>(_ValidateLocationForExternalWarehouse);

            return iValidateLocationForExternalWarehouseExt;
        }
    }
}
