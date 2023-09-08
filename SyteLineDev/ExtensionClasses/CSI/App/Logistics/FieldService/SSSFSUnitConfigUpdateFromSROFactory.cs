//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigUpdateFromSROFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigUpdateFromSROFactory
	{
		public ISSSFSUnitConfigUpdateFromSRO Create(IApplicationDB appDB)
		{
			var _SSSFSUnitConfigUpdateFromSRO = new Logistics.FieldService.SSSFSUnitConfigUpdateFromSRO(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitConfigUpdateFromSROExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitConfigUpdateFromSRO>(_SSSFSUnitConfigUpdateFromSRO);
			
			return iSSSFSUnitConfigUpdateFromSROExt;
		}
	}
}
