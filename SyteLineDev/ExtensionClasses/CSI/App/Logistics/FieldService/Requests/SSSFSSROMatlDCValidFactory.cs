//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROMatlDCValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSROMatlDCValidFactory
    {
        public ISSSFSSROMatlDCValid Create(IApplicationDB appDB)
        {
            var _SSSFSSROMatlDCValid = new Logistics.FieldService.Requests.SSSFSSROMatlDCValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSROMatlDCValidExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROMatlDCValid>(_SSSFSSROMatlDCValid);

            return iSSSFSSROMatlDCValidExt;
        }
    }
}
