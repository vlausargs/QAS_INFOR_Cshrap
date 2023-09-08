//PROJECT NAME: CSIFinance
//CLASS NAME: IsSiteAndHasSameBaseCurrFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class IsSiteAndHasSameBaseCurrFactory
    {
        public IIsSiteAndHasSameBaseCurr Create(IApplicationDB appDB)
        {
            var _IsSiteAndHasSameBaseCurr = new IsSiteAndHasSameBaseCurr(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLJournalsExt = timerfactory.Create<IIsSiteAndHasSameBaseCurr>(_IsSiteAndHasSameBaseCurr);

            return iSLJournalsExt;
        }
    }
}
