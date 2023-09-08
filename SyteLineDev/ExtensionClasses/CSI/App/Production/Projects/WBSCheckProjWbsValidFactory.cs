//PROJECT NAME: Production
//CLASS NAME: WBSCheckProjWbsValidFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class WBSCheckProjWbsValidFactory
	{
		public IWBSCheckProjWbsValid Create(IApplicationDB appDB)
		{
			var _WBSCheckProjWbsValid = new Production.Projects.WBSCheckProjWbsValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWBSCheckProjWbsValidExt = timerfactory.Create<Production.Projects.IWBSCheckProjWbsValid>(_WBSCheckProjWbsValid);
			
			return iWBSCheckProjWbsValidExt;
		}
	}
}
