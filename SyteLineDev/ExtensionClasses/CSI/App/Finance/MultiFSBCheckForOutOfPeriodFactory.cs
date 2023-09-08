//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBCheckForOutOfPeriodFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiFSBCheckForOutOfPeriodFactory
    {
        public IMultiFSBCheckForOutOfPeriod Create(IApplicationDB appDB)
        {
            var _MultiFSBCheckForOutOfPeriod = new MultiFSBCheckForOutOfPeriod(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFsbJournalsExt = timerfactory.Create<IMultiFSBCheckForOutOfPeriod>(_MultiFSBCheckForOutOfPeriod);

            return iSLFsbJournalsExt;
        }
    }
}
