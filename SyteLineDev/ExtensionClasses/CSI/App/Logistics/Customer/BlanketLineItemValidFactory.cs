//PROJECT NAME: CSICustomer
//CLASS NAME: BlanketLineItemValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class BlanketLineItemValidFactory
    {
        public IBlanketLineItemValid Create(IApplicationDB appDB)
        {
            var _BlanketLineItemValid = new BlanketLineItemValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iBlanketLineItemValidExt = timerfactory.Create<IBlanketLineItemValid>(_BlanketLineItemValid);

            return iBlanketLineItemValidExt;
        }
    }
}
