//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetLotLocCostFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetLotLocCostFactory
	{
		public ISSSFSGetLotLocCost Create(IApplicationDB appDB)
		{
			var _SSSFSGetLotLocCost = new Logistics.FieldService.SSSFSGetLotLocCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetLotLocCostExt = timerfactory.Create<Logistics.FieldService.ISSSFSGetLotLocCost>(_SSSFSGetLotLocCost);
			
			return iSSSFSGetLotLocCostExt;
		}
	}
}
