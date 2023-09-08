//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSCopyDefMaintFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSCopyDefMaintFactory
	{
		public ISSSFSCopyDefMaint Create(IApplicationDB appDB)
		{
			var _SSSFSCopyDefMaint = new Logistics.FieldService.SSSFSCopyDefMaint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSCopyDefMaintExt = timerfactory.Create<Logistics.FieldService.ISSSFSCopyDefMaint>(_SSSFSCopyDefMaint);
			
			return iSSSFSCopyDefMaintExt;
		}
	}
}
