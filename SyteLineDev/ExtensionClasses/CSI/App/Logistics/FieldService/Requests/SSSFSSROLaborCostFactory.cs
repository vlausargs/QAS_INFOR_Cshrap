//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROLaborCostFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSROLaborCostFactory
    {
        public ISSSFSSROLaborCost Create(IApplicationDB appDB)
        {
            var _SSSFSSROLaborCost = new Logistics.FieldService.Requests.SSSFSSROLaborCost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSROLaborCostExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROLaborCost>(_SSSFSSROLaborCost);

            return iSSSFSSROLaborCostExt;
        }
    }
}
