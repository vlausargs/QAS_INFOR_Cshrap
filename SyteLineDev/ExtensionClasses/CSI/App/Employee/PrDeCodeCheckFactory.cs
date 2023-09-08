//PROJECT NAME: Employee
//CLASS NAME: PrDeCodeCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PrDeCodeCheckFactory
	{
		public IPrDeCodeCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PrDeCodeCheck = new Employee.PrDeCodeCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrDeCodeCheckExt = timerfactory.Create<Employee.IPrDeCodeCheck>(_PrDeCodeCheck);
			
			return iPrDeCodeCheckExt;
		}
	}
}
