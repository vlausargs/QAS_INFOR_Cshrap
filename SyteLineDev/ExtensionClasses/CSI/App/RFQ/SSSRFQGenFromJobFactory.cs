//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQGenFromJobFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQGenFromJobFactory
    {
        public ISSSRFQGenFromJob Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SSSRFQGenFromJob = new RFQ.SSSRFQGenFromJob(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQGenFromJobExt = timerfactory.Create<RFQ.ISSSRFQGenFromJob>(_SSSRFQGenFromJob);

            return iSSSRFQGenFromJobExt;
        }
    }
}
