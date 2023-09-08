//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSExpenseReconCleanupFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSExpenseReconCleanupFactory
	{
		public ISSSFSExpenseReconCleanup Create(IApplicationDB appDB)
		{
			var _SSSFSExpenseReconCleanup = new Logistics.FieldService.Requests.SSSFSExpenseReconCleanup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSExpenseReconCleanupExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSExpenseReconCleanup>(_SSSFSExpenseReconCleanup);
			
			return iSSSFSExpenseReconCleanupExt;
		}
	}
}
