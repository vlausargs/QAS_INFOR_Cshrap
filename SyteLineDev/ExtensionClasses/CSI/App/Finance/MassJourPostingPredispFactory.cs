//PROJECT NAME: CSIFinance
//CLASS NAME: MassJourPostingPredispFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MassJourPostingPredispFactory
    {
        public IMassJourPostingPredisp Create(IApplicationDB appDB)
        {
            var _MassJourPostingPredisp = new MassJourPostingPredisp(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMassJourPostingPredispExt = timerfactory.Create<IMassJourPostingPredisp>(_MassJourPostingPredisp);

            return iMassJourPostingPredispExt;
        }
    }
}

