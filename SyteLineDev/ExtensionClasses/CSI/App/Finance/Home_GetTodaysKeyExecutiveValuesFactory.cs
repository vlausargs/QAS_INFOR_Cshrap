//PROJECT NAME: CSIFinance
//CLASS NAME: Home_GetTodaysKeyExecutiveValuesFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class Home_GetTodaysKeyExecutiveValuesFactory
    {
        public IHome_GetTodaysKeyExecutiveValues Create(IApplicationDB appDB)
        {
            var _Home_GetTodaysKeyExecutiveValues = new Home_GetTodaysKeyExecutiveValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLExecutivesExt = timerfactory.Create<IHome_GetTodaysKeyExecutiveValues>(_Home_GetTodaysKeyExecutiveValues);

            return iSLExecutivesExt;
        }
    }
}
