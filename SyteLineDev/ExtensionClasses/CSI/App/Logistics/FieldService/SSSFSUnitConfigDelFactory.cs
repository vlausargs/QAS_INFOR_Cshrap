//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSUnitConfigDelFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigDelFactory
	{
		public ISSSFSUnitConfigDel Create(IApplicationDB appDB)
		{
			var _SSSFSUnitConfigDel = new Logistics.FieldService.SSSFSUnitConfigDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitConfigDelExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitConfigDel>(_SSSFSUnitConfigDel);
			
			return iSSSFSUnitConfigDelExt;
		}
	}
}
