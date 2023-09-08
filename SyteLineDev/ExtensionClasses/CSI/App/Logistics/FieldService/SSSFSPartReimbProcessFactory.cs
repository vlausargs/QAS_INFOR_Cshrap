//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPartReimbProcessFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPartReimbProcessFactory
	{
		public ISSSFSPartReimbProcess Create(IApplicationDB appDB)
		{
			var _SSSFSPartReimbProcess = new Logistics.FieldService.SSSFSPartReimbProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPartReimbProcessExt = timerfactory.Create<Logistics.FieldService.ISSSFSPartReimbProcess>(_SSSFSPartReimbProcess);
			
			return iSSSFSPartReimbProcessExt;
		}
	}
}
