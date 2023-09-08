//PROJECT NAME: Employee
//CLASS NAME: PrLogRefreshEmpDefaultsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PrLogRefreshEmpDefaultsFactory
	{
		public IPrLogRefreshEmpDefaults Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PrLogRefreshEmpDefaults = new Employee.PrLogRefreshEmpDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrLogRefreshEmpDefaultsExt = timerfactory.Create<Employee.IPrLogRefreshEmpDefaults>(_PrLogRefreshEmpDefaults);
			
			return iPrLogRefreshEmpDefaultsExt;
		}
	}
}
