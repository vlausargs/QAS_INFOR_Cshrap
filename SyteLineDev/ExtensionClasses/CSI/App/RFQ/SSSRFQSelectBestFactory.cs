//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQSelectBestFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQSelectBestFactory
    {
        public ISSSRFQSelectBest Create(IApplicationDB appDB)
        {
            var _SSSRFQSelectBest = new RFQ.SSSRFQSelectBest(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQSelectBestExt = timerfactory.Create<RFQ.ISSSRFQSelectBest>(_SSSRFQSelectBest);

            return iSSSRFQSelectBestExt;
        }
    }
}
