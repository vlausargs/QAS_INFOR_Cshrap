//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetGanttDatesFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsGetGanttDatesFactory
    {
        public IApsGetGanttDates Create(IApplicationDB appDB)
        {
            var _ApsGetGanttDates = new ApsGetGanttDates(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsGetGanttDatesExt = timerfactory.Create<IApsGetGanttDates>(_ApsGetGanttDates);

            return iApsGetGanttDatesExt;
        }
    }
}
