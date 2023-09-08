//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQGenFromCoFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQGenFromCoFactory
    {
        public ISSSRFQGenFromCo Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SSSRFQGenFromCo = new RFQ.SSSRFQGenFromCo(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQGenFromCoExt = timerfactory.Create<RFQ.ISSSRFQGenFromCo>(_SSSRFQGenFromCo);

            return iSSSRFQGenFromCoExt;
        }
    }
}
