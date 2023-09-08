//PROJECT NAME: CSICustomer
//CLASS NAME: ARAPOffsetCreateARPaymentFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ARAPOffsetCreateARPaymentFactory
    {
        public IARAPOffsetCreateARPayment Create(IApplicationDB appDB)
        {
            var _ARAPOffsetCreateARPayment = new ARAPOffsetCreateARPayment(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iARAPOffsetCreateARPaymentExt = timerfactory.Create<IARAPOffsetCreateARPayment>(_ARAPOffsetCreateARPayment);

            return iARAPOffsetCreateARPaymentExt;
        }
    }
}
