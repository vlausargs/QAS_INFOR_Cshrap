//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBGlPostSFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiFSBGlPostSFactory
    {
        public IMultiFSBGlPostS Create(IApplicationDB appDB)
        {
            var _MultiFSBGlPostS = new MultiFSBGlPostS(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFsbJournalsExt = timerfactory.Create<IMultiFSBGlPostS>(_MultiFSBGlPostS);

            return iSLFsbJournalsExt;
        }
    }
}