//PROJECT NAME: CSICustomer
//CLASS NAME: DoNumForOrderShipValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class DoNumForOrderShipValidFactory
    {
        public IDoNumForOrderShipValid Create(IApplicationDB appDB)
        {
            var _DoNumForOrderShipValid = new DoNumForOrderShipValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDoNumForOrderShipValidExt = timerfactory.Create<IDoNumForOrderShipValid>(_DoNumForOrderShipValid);

            return iDoNumForOrderShipValidExt;
        }
    }
}
