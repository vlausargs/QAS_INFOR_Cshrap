//PROJECT NAME: Employee
//CLASS NAME: PRtrxpValPostChecksFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PRtrxpValPostChecksFactory
	{
		public IPRtrxpValPostChecks Create(IApplicationDB appDB)
		{
			var _PRtrxpValPostChecks = new Employee.PRtrxpValPostChecks(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPRtrxpValPostChecksExt = timerfactory.Create<Employee.IPRtrxpValPostChecks>(_PRtrxpValPostChecks);
			
			return iPRtrxpValPostChecksExt;
		}
	}
}
