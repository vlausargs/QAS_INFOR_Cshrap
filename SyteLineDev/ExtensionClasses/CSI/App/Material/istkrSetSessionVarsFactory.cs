//PROJECT NAME: Material
//CLASS NAME: istkrSetSessionVarsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class istkrSetSessionVarsFactory
	{
		public IistkrSetSessionVars Create(IApplicationDB appDB)
		{
			var _istkrSetSessionVars = new Material.istkrSetSessionVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iistkrSetSessionVarsExt = timerfactory.Create<Material.IistkrSetSessionVars>(_istkrSetSessionVars);
			
			return iistkrSetSessionVarsExt;
		}
	}
}
