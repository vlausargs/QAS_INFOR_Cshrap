//PROJECT NAME: CSIEmployee
//CLASS NAME: PayrollPrintPostGetDefaultsFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PayrollPrintPostGetDefaultsFactory
	{
		public IPayrollPrintPostGetDefaults Create(IApplicationDB appDB)
		{
			var _PayrollPrintPostGetDefaults = new Employee.PayrollPrintPostGetDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPayrollPrintPostGetDefaultsExt = timerfactory.Create<Employee.IPayrollPrintPostGetDefaults>(_PayrollPrintPostGetDefaults);
			
			return iPayrollPrintPostGetDefaultsExt;
		}
	}
}
