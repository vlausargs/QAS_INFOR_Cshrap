//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteMrpWbAndFirmJobFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class DeleteMrpWbAndFirmJobFactory
	{
		public IDeleteMrpWbAndFirmJob Create(IApplicationDB appDB)
		{
			var _DeleteMrpWbAndFirmJob = new Material.DeleteMrpWbAndFirmJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteMrpWbAndFirmJobExt = timerfactory.Create<Material.IDeleteMrpWbAndFirmJob>(_DeleteMrpWbAndFirmJob);
			
			return iDeleteMrpWbAndFirmJobExt;
		}
	}
}
