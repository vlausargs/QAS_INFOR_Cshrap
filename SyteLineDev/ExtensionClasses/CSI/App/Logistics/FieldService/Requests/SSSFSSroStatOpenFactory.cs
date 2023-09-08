//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroStatOpenFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSroStatOpenFactory
    {
        public ISSSFSSroStatOpen Create(IApplicationDB appDB)
        {
            var _SSSFSSroStatOpen = new SSSFSSroStatOpen(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSroStatOpenExt = timerfactory.Create<ISSSFSSroStatOpen>(_SSSFSSroStatOpen);

            return iSSSFSSroStatOpenExt;
        }
    }
}

