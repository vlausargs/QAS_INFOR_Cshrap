//PROJECT NAME: CSICustomer
//CLASS NAME: BlanketLineOrderValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class BlanketLineOrderValidFactory
    {
        public IBlanketLineOrderValid Create(IApplicationDB appDB)
        {
            var _BlanketLineOrderValid = new BlanketLineOrderValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iBlanketLineOrderValidExt = timerfactory.Create<IBlanketLineOrderValid>(_BlanketLineOrderValid);

            return iBlanketLineOrderValidExt;
        }
    }
}
