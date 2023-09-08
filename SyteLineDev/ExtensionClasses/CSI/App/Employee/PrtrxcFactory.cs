//PROJECT NAME: Employee
//CLASS NAME: PrtrxcFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PrtrxcFactory
	{
		public IPrtrxc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Prtrxc = new Employee.Prtrxc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrtrxcExt = timerfactory.Create<Employee.IPrtrxc>(_Prtrxc);
			
			return iPrtrxcExt;
		}
	}
}
