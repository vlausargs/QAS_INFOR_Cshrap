//PROJECT NAME: CSICustomer
//CLASS NAME: CheckCoStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CheckCoStatusFactory
    {
        public ICheckCoStatus Create(IApplicationDB appDB)
        {
            var _CheckCoStatus = new CheckCoStatus(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckCoStatusExt = timerfactory.Create<ICheckCoStatus>(_CheckCoStatus);

            return iCheckCoStatusExt;
        }
    }
}
