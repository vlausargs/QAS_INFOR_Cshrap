//PROJECT NAME: CSIProduct
//CLASS NAME: ApsSyncImmediateSetVarsFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ApsSyncImmediateSetVarsFactory
	{
		public IApsSyncImmediateSetVars Create(IApplicationDB appDB)
		{
			var _ApsSyncImmediateSetVars = new Production.ApsSyncImmediateSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsSyncImmediateSetVarsExt = timerfactory.Create<Production.IApsSyncImmediateSetVars>(_ApsSyncImmediateSetVars);
			
			return iApsSyncImmediateSetVarsExt;
		}
	}
}
