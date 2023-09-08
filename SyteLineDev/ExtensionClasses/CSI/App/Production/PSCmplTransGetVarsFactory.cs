//PROJECT NAME: Production
//CLASS NAME: PSCmplTransGetVarsFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PSCmplTransGetVarsFactory
	{
		public IPSCmplTransGetVars Create(IApplicationDB appDB)
		{
			var _PSCmplTransGetVars = new Production.PSCmplTransGetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSCmplTransGetVarsExt = timerfactory.Create<Production.IPSCmplTransGetVars>(_PSCmplTransGetVars);
			
			return iPSCmplTransGetVarsExt;
		}
	}
}
