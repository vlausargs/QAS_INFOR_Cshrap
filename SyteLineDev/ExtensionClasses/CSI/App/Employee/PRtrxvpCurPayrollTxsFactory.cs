//PROJECT NAME: Employee
//CLASS NAME: PRtrxvpCurPayrollTxsFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PRtrxvpCurPayrollTxsFactory
	{
		public IPRtrxvpCurPayrollTxs Create(IApplicationDB appDB)
		{
			var _PRtrxvpCurPayrollTxs = new Employee.PRtrxvpCurPayrollTxs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPRtrxvpCurPayrollTxsExt = timerfactory.Create<Employee.IPRtrxvpCurPayrollTxs>(_PRtrxvpCurPayrollTxs);
			
			return iPRtrxvpCurPayrollTxsExt;
		}
	}
}
