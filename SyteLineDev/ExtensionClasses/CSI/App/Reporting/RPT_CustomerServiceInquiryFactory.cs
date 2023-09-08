//PROJECT NAME: CSIReport
//CLASS NAME: RPT_CustomerServiceInquiryFactory.cs

using CSI.MG;

namespace CSI.Reporting
{
    public class RPT_CustomerServiceInquiryFactory
    {
        public IRPT_CustomerServiceInquiry Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _RPT_CustomerServiceInquiry = new RPT_CustomerServiceInquiry(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRPT_CustomerServiceInquiryExt = timerfactory.Create<IRPT_CustomerServiceInquiry>(_RPT_CustomerServiceInquiry);

            return iRPT_CustomerServiceInquiryExt;
        }
    }
}
