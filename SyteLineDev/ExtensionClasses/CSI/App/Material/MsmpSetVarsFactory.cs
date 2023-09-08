//PROJECT NAME: CSIMaterial
//CLASS NAME: MsmpSetVarsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class MsmpSetVarsFactory
	{
		public IMsmpSetVars Create(IApplicationDB appDB)
		{
			var _MsmpSetVars = new Material.MsmpSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMsmpSetVarsExt = timerfactory.Create<Material.IMsmpSetVars>(_MsmpSetVars);
			
			return iMsmpSetVarsExt;
		}
	}
}
