//PROJECT NAME: CSICustomer
//CLASS NAME: CitemXFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CitemXFactory
    {
        public ICitemX Create(IApplicationDB appDB)
        {
            var _CitemX = new CitemX(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCitemXExt = timerfactory.Create<ICitemX>(_CitemX);

            return iCitemXExt;
        }
    }
}
