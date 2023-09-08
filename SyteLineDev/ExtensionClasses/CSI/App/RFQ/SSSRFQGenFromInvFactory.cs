//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQGenFromInvFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQGenFromInvFactory
    {
        public ISSSRFQGenFromInv Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SSSRFQGenFromInv = new RFQ.SSSRFQGenFromInv(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQGenFromInvExt = timerfactory.Create<RFQ.ISSSRFQGenFromInv>(_SSSRFQGenFromInv);

            return iSSSRFQGenFromInvExt;
        }
    }
}
