//PROJECT NAME: Admin
//CLASS NAME: AppWorkflowParmUpdateFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class AppWorkflowParmUpdateFactory
	{
		public IAppWorkflowParmUpdate Create(IApplicationDB appDB)
		{
			var _AppWorkflowParmUpdate = new Admin.AppWorkflowParmUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppWorkflowParmUpdateExt = timerfactory.Create<Admin.IAppWorkflowParmUpdate>(_AppWorkflowParmUpdate);
			
			return iAppWorkflowParmUpdateExt;
		}
	}
}
