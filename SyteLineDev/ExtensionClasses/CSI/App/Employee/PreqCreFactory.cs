//PROJECT NAME: Employee
//CLASS NAME: PreqCreFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PreqCreFactory
	{
		public IPreqCre Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PreqCre = new Employee.PreqCre(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreqCreExt = timerfactory.Create<Employee.IPreqCre>(_PreqCre);
			
			return iPreqCreExt;
		}
	}
}
