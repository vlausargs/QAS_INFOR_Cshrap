//PROJECT NAME: CSIFinance
//CLASS NAME: IsExecutiveHomeSiteGroupValidFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class IsExecutiveHomeSiteGroupValidFactory
    {
        public IIsExecutiveHomeSiteGroupValid Create(IApplicationDB appDB)
        {
            var _IsExecutiveHomeSiteGroupValid = new IsExecutiveHomeSiteGroupValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLExecutivesExt = timerfactory.Create<IIsExecutiveHomeSiteGroupValid>(_IsExecutiveHomeSiteGroupValid);

            return iSLExecutivesExt;
        }
    }
}
