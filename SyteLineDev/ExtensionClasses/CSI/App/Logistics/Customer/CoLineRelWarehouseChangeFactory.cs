//PROJECT NAME: CSICustomer
//CLASS NAME: CoLineRelWarehouseChangeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CoLineRelWarehouseChangeFactory
    {
        public ICoLineRelWarehouseChange Create(IApplicationDB appDB)
        {
            var _CoLineRelWarehouseChange = new CoLineRelWarehouseChange(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoLineRelWarehouseChangeExt = timerfactory.Create<ICoLineRelWarehouseChange>(_CoLineRelWarehouseChange);

            return iCoLineRelWarehouseChangeExt;
        }
    }
}
