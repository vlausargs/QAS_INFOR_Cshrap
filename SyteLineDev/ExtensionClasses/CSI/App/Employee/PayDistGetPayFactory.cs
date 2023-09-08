//PROJECT NAME: CSIEmployee
//CLASS NAME: PayDistGetPayFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PayDistGetPayFactory
	{
		public IPayDistGetPay Create(IApplicationDB appDB)
		{
			var _PayDistGetPay = new Employee.PayDistGetPay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPayDistGetPayExt = timerfactory.Create<Employee.IPayDistGetPay>(_PayDistGetPay);
			
			return iPayDistGetPayExt;
		}
	}
}
