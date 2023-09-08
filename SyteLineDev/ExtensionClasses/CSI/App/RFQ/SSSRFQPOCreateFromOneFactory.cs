//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQPOCreateFromOneFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQPOCreateFromOneFactory
    {
        public ISSSRFQPOCreateFromOne Create(IApplicationDB appDB)
        {
            var _SSSRFQPOCreateFromOne = new RFQ.SSSRFQPOCreateFromOne(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQPOCreateFromOneExt = timerfactory.Create<RFQ.ISSSRFQPOCreateFromOne>(_SSSRFQPOCreateFromOne);

            return iSSSRFQPOCreateFromOneExt;
        }
    }
}
