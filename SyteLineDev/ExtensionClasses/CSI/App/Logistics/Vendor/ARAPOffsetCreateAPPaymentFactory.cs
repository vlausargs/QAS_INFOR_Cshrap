//PROJECT NAME: CSIVendor
//CLASS NAME: ARAPOffsetCreateAPPaymentFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class ARAPOffsetCreateAPPaymentFactory
    {
        public IARAPOffsetCreateAPPayment Create(IApplicationDB appDB)
        {
            var _ARAPOffsetCreateAPPayment = new ARAPOffsetCreateAPPayment(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iARAPOffsetCreateAPPaymentExt = timerfactory.Create<IARAPOffsetCreateAPPayment>(_ARAPOffsetCreateAPPayment);

            return iARAPOffsetCreateAPPaymentExt;
        }
    }
}
