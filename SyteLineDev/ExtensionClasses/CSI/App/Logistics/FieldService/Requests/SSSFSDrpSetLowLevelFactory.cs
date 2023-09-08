//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDrpSetLowLevelFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSDrpSetLowLevelFactory
	{
		public ISSSFSDrpSetLowLevel Create(IApplicationDB appDB)
		{
			var _SSSFSDrpSetLowLevel = new Logistics.FieldService.Requests.SSSFSDrpSetLowLevel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSDrpSetLowLevelExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSDrpSetLowLevel>(_SSSFSDrpSetLowLevel);
			
			return iSSSFSDrpSetLowLevelExt;
		}
	}
}
