//PROJECT NAME: CSIAdmin
//CLASS NAME: BI_Refresh_ViewsFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class BI_Refresh_ViewsFactory
	{
		public IBI_Refresh_Views Create(IApplicationDB appDB)
		{
			var _BI_Refresh_Views = new Admin.BI_Refresh_Views(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBI_Refresh_ViewsExt = timerfactory.Create<Admin.IBI_Refresh_Views>(_BI_Refresh_Views);
			
			return iBI_Refresh_ViewsExt;
		}
	}
}
