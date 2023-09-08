//PROJECT NAME: CSIMaterial
//CLASS NAME: SiteLotValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class SiteLotValidFactory
    {
        public ISiteLotValid Create(IApplicationDB appDB)
        {
            var _SiteLotValid = new SiteLotValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSiteLotValidExt = timerfactory.Create<ISiteLotValid>(_SiteLotValid);

            return iSiteLotValidExt;
        }
    }
}
