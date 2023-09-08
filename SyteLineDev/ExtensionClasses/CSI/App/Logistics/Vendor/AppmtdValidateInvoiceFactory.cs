//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtdValidateInvoiceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class AppmtdValidateInvoiceFactory
    {
        public IAppmtdValidateInvoice Create(IApplicationDB appDB)
        {
            var _AppmtdValidateInvoice = new Logistics.Vendor.AppmtdValidateInvoice(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtdValidateInvoiceExt = timerfactory.Create<Logistics.Vendor.IAppmtdValidateInvoice>(_AppmtdValidateInvoice);

            return iAppmtdValidateInvoiceExt;
        }
    }
}
