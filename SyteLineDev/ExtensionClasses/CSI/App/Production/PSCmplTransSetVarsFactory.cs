//PROJECT NAME: Production
//CLASS NAME: PSCmplTransSetVarsFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PSCmplTransSetVarsFactory
	{
		public IPSCmplTransSetVars Create(IApplicationDB appDB)
		{
			var _PSCmplTransSetVars = new Production.PSCmplTransSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSCmplTransSetVarsExt = timerfactory.Create<Production.IPSCmplTransSetVars>(_PSCmplTransSetVars);
			
			return iPSCmplTransSetVarsExt;
		}
	}
}
