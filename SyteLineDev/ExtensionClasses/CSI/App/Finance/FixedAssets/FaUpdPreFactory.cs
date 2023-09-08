//PROJECT NAME: CSIFinance
//CLASS NAME: FaUpdPreFactory.cs

using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public class FaUpdPreFactory
    {
        public IFaUpdPre Create(IApplicationDB appDB)
        {
            var _FaUpdPre = new FaUpdPre(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFaDeprsExt = timerfactory.Create<IFaUpdPre>(_FaUpdPre);

            return iSLFaDeprsExt;
        }
    }
}
