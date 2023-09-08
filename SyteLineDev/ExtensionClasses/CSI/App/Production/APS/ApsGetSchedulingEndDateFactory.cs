//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetSchedulingEndDateFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsGetSchedulingEndDateFactory
    {
        public IApsGetSchedulingEndDate Create(IApplicationDB appDB)
        {
            var _ApsGetSchedulingEndDate = new ApsGetSchedulingEndDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsGetSchedulingEndDateExt = timerfactory.Create<IApsGetSchedulingEndDate>(_ApsGetSchedulingEndDate);

            return iApsGetSchedulingEndDateExt;
        }
    }
}
