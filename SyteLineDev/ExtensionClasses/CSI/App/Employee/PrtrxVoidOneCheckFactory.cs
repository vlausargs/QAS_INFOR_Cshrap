//PROJECT NAME: Employee
//CLASS NAME: PrtrxVoidOneCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PrtrxVoidOneCheckFactory
	{
		public IPrtrxVoidOneCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PrtrxVoidOneCheck = new Employee.PrtrxVoidOneCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrtrxVoidOneCheckExt = timerfactory.Create<Employee.IPrtrxVoidOneCheck>(_PrtrxVoidOneCheck);
			
			return iPrtrxVoidOneCheckExt;
		}
	}
}
