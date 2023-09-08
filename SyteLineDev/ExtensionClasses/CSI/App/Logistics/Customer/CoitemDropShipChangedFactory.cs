//PROJECT NAME: CSICustomer
//CLASS NAME: CoitemDropShipChangedFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CoitemDropShipChangedFactory
    {
        public ICoitemDropShipChanged Create(IApplicationDB appDB)
        {
            var _CoitemDropShipChanged = new CoitemDropShipChanged(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoitemDropShipChangedExt = timerfactory.Create<ICoitemDropShipChanged>(_CoitemDropShipChanged);

            return iCoitemDropShipChangedExt;
        }
    }
}
