//PROJECT NAME: Employee
//CLASS NAME: SVacFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class SVacFactory
	{
		public ISVac Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SVac = new Employee.SVac(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSVacExt = timerfactory.Create<Employee.ISVac>(_SVac);
			
			return iSVacExt;
		}
	}
}
