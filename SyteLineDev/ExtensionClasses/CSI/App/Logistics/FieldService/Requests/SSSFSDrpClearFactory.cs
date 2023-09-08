//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDrpClearFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSDrpClearFactory
	{
		public ISSSFSDrpClear Create(IApplicationDB appDB)
		{
			var _SSSFSDrpClear = new Logistics.FieldService.Requests.SSSFSDrpClear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSDrpClearExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSDrpClear>(_SSSFSDrpClear);
			
			return iSSSFSDrpClearExt;
		}
	}
}
