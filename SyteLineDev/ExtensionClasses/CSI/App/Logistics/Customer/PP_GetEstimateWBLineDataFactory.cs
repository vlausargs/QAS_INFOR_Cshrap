//PROJECT NAME: CSICustomer
//CLASS NAME: PP_GetEstimateWBLineDataFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class PP_GetEstimateWBLineDataFactory
    {
        public IPP_GetEstimateWBLineData Create(IApplicationDB appDB)
        {
            var _PP_GetEstimateWBLineData = new PP_GetEstimateWBLineData(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPP_GetEstimateWBLineDataExt = timerfactory.Create<IPP_GetEstimateWBLineData>(_PP_GetEstimateWBLineData);

            return iPP_GetEstimateWBLineDataExt;
        }
    }
}
