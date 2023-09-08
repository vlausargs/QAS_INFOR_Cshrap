//PROJECT NAME: Admin
//CLASS NAME: AppWorkflowUpdateFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class AppWorkflowUpdateFactory
	{
		public IAppWorkflowUpdate Create(IApplicationDB appDB)
		{
			var _AppWorkflowUpdate = new Admin.AppWorkflowUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppWorkflowUpdateExt = timerfactory.Create<Admin.IAppWorkflowUpdate>(_AppWorkflowUpdate);
			
			return iAppWorkflowUpdateExt;
		}
	}
}
