//PROJECT NAME: CSIMaterial
//CLASS NAME: MO_JobScrapPFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class MO_JobScrapPFactory
    {
        public IMO_JobScrapP Create(IApplicationDB appDB)
        {
            var _MO_JobScrapP = new MO_JobScrapP(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMO_JobScrapPExt = timerfactory.Create<IMO_JobScrapP>(_MO_JobScrapP);

            return iMO_JobScrapPExt;
        }
    }
}
