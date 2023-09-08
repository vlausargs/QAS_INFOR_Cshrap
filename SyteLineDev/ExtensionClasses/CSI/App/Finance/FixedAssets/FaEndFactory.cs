//PROJECT NAME: CSIFinance
//CLASS NAME: FaEndFactory.cs

using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public class FaEndFactory
    {
        public IFaEnd Create(IApplicationDB appDB)
        {
            var _FaEnd = new FaEnd(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFaDeprsExt = timerfactory.Create<IFaEnd>(_FaEnd);

            return iSLFaDeprsExt;
        }
    }
}
