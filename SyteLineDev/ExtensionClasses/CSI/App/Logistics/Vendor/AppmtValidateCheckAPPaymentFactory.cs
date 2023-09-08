//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtValidateCheckAPPaymentFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtValidateCheckAPPaymentFactory
    {
        public IAppmtValidateCheckAPPayment Create(IApplicationDB appDB)
        {
            var _AppmtValidateCheckAPPayment = new Logistics.Vendor.AppmtValidateCheckAPPayment(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtValidateCheckAPPaymentExt = timerfactory.Create<Logistics.Vendor.IAppmtValidateCheckAPPayment>(_AppmtValidateCheckAPPayment);

            return iAppmtValidateCheckAPPaymentExt;
        }
    }
}
