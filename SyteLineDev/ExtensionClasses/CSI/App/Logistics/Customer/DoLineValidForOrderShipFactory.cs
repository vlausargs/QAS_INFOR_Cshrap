//PROJECT NAME: CSICustomer
//CLASS NAME: DoLineValidForOrderShipFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class DoLineValidForOrderShipFactory
    {
        public IDoLineValidForOrderShip Create(IApplicationDB appDB)
        {
            var _DoLineValidForOrderShip = new DoLineValidForOrderShip(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDoLineValidForOrderShipExt = timerfactory.Create<IDoLineValidForOrderShip>(_DoLineValidForOrderShip);

            return iDoLineValidForOrderShipExt;
        }
    }
}
