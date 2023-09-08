//PROJECT NAME: Employee
//CLASS NAME: EmptyPayrollLogTableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class EmptyPayrollLogTableFactory
	{
		public IEmptyPayrollLogTable Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EmptyPayrollLogTable = new Employee.EmptyPayrollLogTable(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEmptyPayrollLogTableExt = timerfactory.Create<Employee.IEmptyPayrollLogTable>(_EmptyPayrollLogTable);
			
			return iEmptyPayrollLogTableExt;
		}
	}
}
