//PROJECT NAME: Material
//CLASS NAME: istkrPostSaveSetVarsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class istkrPostSaveSetVarsFactory
	{
		public IistkrPostSaveSetVars Create(IApplicationDB appDB)
		{
			var _istkrPostSaveSetVars = new Material.istkrPostSaveSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iistkrPostSaveSetVarsExt = timerfactory.Create<Material.IistkrPostSaveSetVars>(_istkrPostSaveSetVars);
			
			return iistkrPostSaveSetVarsExt;
		}
	}
}
