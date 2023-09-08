//PROJECT NAME: Employee
//CLASS NAME: PRtrxp1pPostChecksFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PRtrxp1pPostChecksFactory
	{
		public IPRtrxp1pPostChecks Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PRtrxp1pPostChecks = new Employee.PRtrxp1pPostChecks(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPRtrxp1pPostChecksExt = timerfactory.Create<Employee.IPRtrxp1pPostChecks>(_PRtrxp1pPostChecks);
			
			return iPRtrxp1pPostChecksExt;
		}
	}
}
