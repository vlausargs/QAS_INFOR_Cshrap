//PROJECT NAME: Finance.AR
//CLASS NAME: GainLossArFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.AR
{
    public class GainLossArFactory
    {
        public IGainLossAr Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _GainLossAr = new Finance.AR.GainLossAr(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGainLossArExt = timerfactory.Create<Finance.AR.IGainLossAr>(_GainLossAr);

            return iGainLossArExt;
        }
    }
}
