//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroLaborRateFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSroLaborRateFactory
    {
        public ISSSFSSroLaborRate Create(IApplicationDB appDB)
        {
            var _SSSFSSroLaborRate = new Logistics.FieldService.Requests.SSSFSSroLaborRate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSroLaborRateExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroLaborRate>(_SSSFSSroLaborRate);

            return iSSSFSSroLaborRateExt;
        }
    }
}
