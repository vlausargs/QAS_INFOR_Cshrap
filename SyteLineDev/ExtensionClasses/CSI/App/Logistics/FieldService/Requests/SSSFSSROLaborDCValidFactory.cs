//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROLaborDCValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSROLaborDCValidFactory
    {
        public ISSSFSSROLaborDCValid Create(IApplicationDB appDB)
        {
            var _SSSFSSROLaborDCValid = new SSSFSSROLaborDCValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSROLaborDCValidExt = timerfactory.Create<ISSSFSSROLaborDCValid>(_SSSFSSROLaborDCValid);

            return iSSSFSSROLaborDCValidExt;
        }
    }
}

