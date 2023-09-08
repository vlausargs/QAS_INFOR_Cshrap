//PROJECT NAME: Employee
//CLASS NAME: PrtrxSetRegularHrsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PrtrxSetRegularHrsFactory
	{
		public IPrtrxSetRegularHrs Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PrtrxSetRegularHrs = new Employee.PrtrxSetRegularHrs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrtrxSetRegularHrsExt = timerfactory.Create<Employee.IPrtrxSetRegularHrs>(_PrtrxSetRegularHrs);
			
			return iPrtrxSetRegularHrsExt;
		}
	}
}
