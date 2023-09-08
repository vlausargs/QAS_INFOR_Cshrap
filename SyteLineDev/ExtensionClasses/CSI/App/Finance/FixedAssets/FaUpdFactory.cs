//PROJECT NAME: CSIFinance
//CLASS NAME: FaUpdFactory.cs

using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public class FaUpdFactory
    {
        public IFaUpd Create(IApplicationDB appDB)
        {
            var _FaUpd = new FaUpd(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFaDeprsExt = timerfactory.Create<IFaUpd>(_FaUpd);

            return iSLFaDeprsExt;
        }
    }
}
