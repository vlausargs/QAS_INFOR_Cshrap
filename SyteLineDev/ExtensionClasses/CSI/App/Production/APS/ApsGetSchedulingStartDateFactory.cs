//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetSchedulingStartDateFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsGetSchedulingStartDateFactory
    {
        public IApsGetSchedulingStartDate Create(IApplicationDB appDB)
        {
            var _ApsGetSchedulingStartDate = new ApsGetSchedulingStartDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsGetSchedulingStartDateExt = timerfactory.Create<IApsGetSchedulingStartDate>(_ApsGetSchedulingStartDate);

            return iApsGetSchedulingStartDateExt;
        }
    }
}
