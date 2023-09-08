//PROJECT NAME: CSIProduct
//CLASS NAME: EngWBSetSessionVarsFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class EngWBSetSessionVarsFactory
	{
		public IEngWBSetSessionVars Create(IApplicationDB appDB)
		{
			var _EngWBSetSessionVars = new Production.EngWBSetSessionVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEngWBSetSessionVarsExt = timerfactory.Create<Production.IEngWBSetSessionVars>(_EngWBSetSessionVars);
			
			return iEngWBSetSessionVarsExt;
		}
	}
}
