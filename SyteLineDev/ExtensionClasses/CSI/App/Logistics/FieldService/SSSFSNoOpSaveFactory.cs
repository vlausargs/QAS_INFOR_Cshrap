//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSNoOpSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSNoOpSaveFactory
	{
		public ISSSFSNoOpSave Create(IApplicationDB appDB)
		{
			var _SSSFSNoOpSave = new Logistics.FieldService.SSSFSNoOpSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSNoOpSaveExt = timerfactory.Create<Logistics.FieldService.ISSSFSNoOpSave>(_SSSFSNoOpSave);
			
			return iSSSFSNoOpSaveExt;
		}
	}
}
