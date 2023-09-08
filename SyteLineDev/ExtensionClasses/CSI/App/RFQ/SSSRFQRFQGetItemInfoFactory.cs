//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQRFQGetItemInfoFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQRFQGetItemInfoFactory
    {
        public ISSSRFQRFQGetItemInfo Create(IApplicationDB appDB)
        {
            var _SSSRFQRFQGetItemInfo = new RFQ.SSSRFQRFQGetItemInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQRFQGetItemInfoExt = timerfactory.Create<RFQ.ISSSRFQRFQGetItemInfo>(_SSSRFQRFQGetItemInfo);

            return iSSSRFQRFQGetItemInfoExt;
        }
    }
}
