//PROJECT NAME: CSICustomer
//CLASS NAME: PP_ProcessPrintingEstimateWBPriceDrivenFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class PP_ProcessPrintingEstimateWBPriceDrivenFactory
    {
        public IPP_ProcessPrintingEstimateWBPriceDriven Create(IApplicationDB appDB)
        {
            var _PP_ProcessPrintingEstimateWBPriceDriven = new PP_ProcessPrintingEstimateWBPriceDriven(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPP_ProcessPrintingEstimateWBPriceDrivenExt = timerfactory.Create<IPP_ProcessPrintingEstimateWBPriceDriven>(_PP_ProcessPrintingEstimateWBPriceDriven);

            return iPP_ProcessPrintingEstimateWBPriceDrivenExt;
        }
    }
}
