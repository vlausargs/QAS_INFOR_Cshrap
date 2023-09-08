//PROJECT NAME: CSIFinance
//CLASS NAME: GLYearEndClosingInputCheckFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class GLYearEndClosingInputCheckFactory
    {
        public IGLYearEndClosingInputCheck Create(IApplicationDB appDB)
        {
            var _GLYearEndClosingInputCheck = new GLYearEndClosingInputCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLJournalsExt = timerfactory.Create<IGLYearEndClosingInputCheck>(_GLYearEndClosingInputCheck);

            return iSLJournalsExt;
        }
    }
}
