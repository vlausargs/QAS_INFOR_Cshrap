//PROJECT NAME: Employee
//CLASS NAME: CalcRvwFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class CalcRvwFactory
	{
		public ICalcRvw Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalcRvw = new Employee.CalcRvw(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcRvwExt = timerfactory.Create<Employee.ICalcRvw>(_CalcRvw);
			
			return iCalcRvwExt;
		}
	}
}
