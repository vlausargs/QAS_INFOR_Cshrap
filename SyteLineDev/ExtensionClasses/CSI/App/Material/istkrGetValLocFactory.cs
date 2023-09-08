//PROJECT NAME: Material
//CLASS NAME: istkrGetValLocFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class istkrGetValLocFactory
	{
		public IistkrGetValLoc Create(IApplicationDB appDB)
		{
			var _istkrGetValLoc = new Material.istkrGetValLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iistkrGetValLocExt = timerfactory.Create<Material.IistkrGetValLoc>(_istkrGetValLoc);
			
			return iistkrGetValLocExt;
		}
	}
}
