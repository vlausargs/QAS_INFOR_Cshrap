//PROJECT NAME: Production
//CLASS NAME: PP_CalcSetupAndRunTimes_LookupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PP_CalcSetupAndRunTimes_LookupFactory
	{
		public IPP_CalcSetupAndRunTimes_Lookup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_CalcSetupAndRunTimes_Lookup = new Production.PP_CalcSetupAndRunTimes_Lookup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_CalcSetupAndRunTimes_LookupExt = timerfactory.Create<Production.IPP_CalcSetupAndRunTimes_Lookup>(_PP_CalcSetupAndRunTimes_Lookup);
			
			return iPP_CalcSetupAndRunTimes_LookupExt;
		}
	}
}
