//PROJECT NAME: CSICustomer
//CLASS NAME: EitemXFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EitemXFactory
    {
        public IEitemX Create(IApplicationDB appDB)
        {
            var _EitemX = new EitemX(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEitemXExt = timerfactory.Create<IEitemX>(_EitemX);

            return iEitemXExt;
        }
    }
}
