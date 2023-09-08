//PROJECT NAME: CSICustomer
//CLASS NAME: SSSOPMReverseFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSOPMReverseFactory
    {
        public ISSSOPMReverse Create(IApplicationDB appDB)
        {
            var _SSSOPMReverse = new Logistics.Customer.SSSOPMReverse(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSOPMReverseExt = timerfactory.Create<Logistics.Customer.ISSSOPMReverse>(_SSSOPMReverse);

            return iSSSOPMReverseExt;
        }
    }
}
