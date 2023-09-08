//PROJECT NAME: CSICustomer
//CLASS NAME: ARPaymentDistributeChargebacksFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ARPaymentDistributeChargebacksFactory
    {
        public IARPaymentDistributeChargebacks Create(IApplicationDB appDB)
        {
            var _ARPaymentDistributeChargebacks = new ARPaymentDistributeChargebacks(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iARPaymentDistributeChargebacksExt = timerfactory.Create<IARPaymentDistributeChargebacks>(_ARPaymentDistributeChargebacks);

            return iARPaymentDistributeChargebacksExt;
        }
    }
}
