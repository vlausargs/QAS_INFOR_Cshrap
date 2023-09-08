//PROJECT NAME: CSICustomer
//CLASS NAME: PP_ProcessPrintingEstimateWBFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class PP_ProcessPrintingEstimateWBFactory
    {
        public IPP_ProcessPrintingEstimateWB Create(IApplicationDB appDB)
        {
            var _PP_ProcessPrintingEstimateWB = new PP_ProcessPrintingEstimateWB(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPP_ProcessPrintingEstimateWBExt = timerfactory.Create<IPP_ProcessPrintingEstimateWB>(_PP_ProcessPrintingEstimateWB);

            return iPP_ProcessPrintingEstimateWBExt;
        }
    }
}
