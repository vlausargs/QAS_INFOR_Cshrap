//PROJECT NAME: CSICustomer
//CLASS NAME: GetReportTemplateParmFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class GetReportTemplateParmFactory
    {
        public IGetReportTemplateParm Create(IApplicationDB appDB)
        {
            var _GetReportTemplateParm = new GetReportTemplateParm(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetReportTemplateParmExt = timerfactory.Create<IGetReportTemplateParm>(_GetReportTemplateParm);

            return iGetReportTemplateParmExt;
        }
    }
}
