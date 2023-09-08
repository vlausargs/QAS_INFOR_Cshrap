//PROJECT NAME: CSICustomer
//CLASS NAME: AU_CheckPriceAdjustInvoiceCountFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class AU_CheckPriceAdjustInvoiceCountFactory
    {
        public IAU_CheckPriceAdjustInvoiceCount Create(IApplicationDB appDB)
        {
            var _AU_CheckPriceAdjustInvoiceCount = new AU_CheckPriceAdjustInvoiceCount(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_CheckPriceAdjustInvoiceCountExt = timerfactory.Create<IAU_CheckPriceAdjustInvoiceCount>(_AU_CheckPriceAdjustInvoiceCount);

            return iAU_CheckPriceAdjustInvoiceCountExt;
        }
    }
}
