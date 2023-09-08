//PROJECT NAME: Employee
//CLASS NAME: PR01VRPVoidChecksFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PR01VRPVoidChecksFactory
	{
		public IPR01VRPVoidChecks Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PR01VRPVoidChecks = new Employee.PR01VRPVoidChecks(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPR01VRPVoidChecksExt = timerfactory.Create<Employee.IPR01VRPVoidChecks>(_PR01VRPVoidChecks);
			
			return iPR01VRPVoidChecksExt;
		}
	}
}
