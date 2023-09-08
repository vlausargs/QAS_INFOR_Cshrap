//PROJECT NAME: CSIMaterial
//CLASS NAME: MvPostSetVarsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class MvPostSetVarsFactory
	{
		public IMvPostSetVars Create(IApplicationDB appDB)
		{
			var _MvPostSetVars = new Material.MvPostSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMvPostSetVarsExt = timerfactory.Create<Material.IMvPostSetVars>(_MvPostSetVars);
			
			return iMvPostSetVarsExt;
		}
	}
}
