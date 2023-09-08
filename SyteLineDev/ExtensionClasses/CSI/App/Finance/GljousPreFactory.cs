//PROJECT NAME: CSIFinance
//CLASS NAME: GljousPreFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class GljousPreFactory
    {
        public IGljousPre Create(IApplicationDB appDB)
        {
            var _GljousPre = new GljousPre(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLJournalsExt = timerfactory.Create<IGljousPre>(_GljousPre);

            return iSLJournalsExt;
        }
    }
}
