//PROJECT NAME: Employee
//CLASS NAME: HrvacDoProcessFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class HrvacDoProcessFactory
	{
		public IHrvacDoProcess Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _HrvacDoProcess = new Employee.HrvacDoProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHrvacDoProcessExt = timerfactory.Create<Employee.IHrvacDoProcess>(_HrvacDoProcess);
			
			return iHrvacDoProcessExt;
		}
	}
}
