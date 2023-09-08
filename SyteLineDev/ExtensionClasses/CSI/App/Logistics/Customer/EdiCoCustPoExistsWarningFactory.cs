//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoCustPoExistsWarningFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EdiCoCustPoExistsWarningFactory
    {
        public IEdiCoCustPoExistsWarning Create(IApplicationDB appDB)
        {
            var _EdiCoCustPoExistsWarning = new Logistics.Customer.EdiCoCustPoExistsWarning(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEdiCoCustPoExistsWarningExt = timerfactory.Create<Logistics.Customer.IEdiCoCustPoExistsWarning>(_EdiCoCustPoExistsWarning);

            return iEdiCoCustPoExistsWarningExt;
        }
    }
}
