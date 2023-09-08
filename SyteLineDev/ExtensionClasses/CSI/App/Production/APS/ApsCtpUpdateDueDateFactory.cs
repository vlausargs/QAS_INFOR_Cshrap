//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpUpdateDueDateFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpUpdateDueDateFactory
    {
        public IApsCtpUpdateDueDate Create(IApplicationDB appDB)
        {
            var _ApsCtpUpdateDueDate = new ApsCtpUpdateDueDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpUpdateDueDateExt = timerfactory.Create<IApsCtpUpdateDueDate>(_ApsCtpUpdateDueDate);

            return iApsCtpUpdateDueDateExt;
        }
    }
}
