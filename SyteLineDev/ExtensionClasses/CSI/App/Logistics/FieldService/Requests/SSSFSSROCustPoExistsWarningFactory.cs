//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROCustPoExistsWarningFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSROCustPoExistsWarningFactory
    {
        public ISSSFSSROCustPoExistsWarning Create(IApplicationDB appDB)
        {
            var _SSSFSSROCustPoExistsWarning = new SSSFSSROCustPoExistsWarning(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSROCustPoExistsWarningExt = timerfactory.Create<ISSSFSSROCustPoExistsWarning>(_SSSFSSROCustPoExistsWarning);

            return iSSSFSSROCustPoExistsWarningExt;
        }
    }
}
