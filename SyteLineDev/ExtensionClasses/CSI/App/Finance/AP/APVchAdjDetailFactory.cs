//PROJECT NAME: CSIVendor
//CLASS NAME: APVchAdjDetailFactory.cs

using CSI.MG;

namespace CSI.Finance.AP
{
    public class APVchAdjDetailFactory
    {
        public IAPVchAdjDetail Create(IApplicationDB appDB)
        {
            var _APVchAdjDetail = new APVchAdjDetail(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAPVchAdjDetailExt = timerfactory.Create<IAPVchAdjDetail>(_APVchAdjDetail);

            return iAPVchAdjDetailExt;
        }
    }
}
