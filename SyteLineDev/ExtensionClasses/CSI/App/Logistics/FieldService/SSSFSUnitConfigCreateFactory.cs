//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigCreateFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigCreateFactory
	{
		public ISSSFSUnitConfigCreate Create(IApplicationDB appDB)
		{
			var _SSSFSUnitConfigCreate = new Logistics.FieldService.SSSFSUnitConfigCreate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitConfigCreateExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitConfigCreate>(_SSSFSUnitConfigCreate);
			
			return iSSSFSUnitConfigCreateExt;
		}
	}
}
