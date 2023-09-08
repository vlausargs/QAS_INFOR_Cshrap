//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROOperCalcDurationFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSROOperCalcDurationFactory
    {
        public ISSSFSSROOperCalcDuration Create(IApplicationDB appDB)
        {
            var _SSSFSSROOperCalcDuration = new SSSFSSROOperCalcDuration(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSROOperCalcDurationExt = timerfactory.Create<ISSSFSSROOperCalcDuration>(_SSSFSSROOperCalcDuration);

            return iSSSFSSROOperCalcDurationExt;
        }
    }
}