//PROJECT NAME: CSIEmployee
//CLASS NAME: GetPayrollParmsFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class GetPayrollParmsFactory
	{
		public IGetPayrollParms Create(IApplicationDB appDB)
		{
			var _GetPayrollParms = new Employee.GetPayrollParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPayrollParmsExt = timerfactory.Create<Employee.IGetPayrollParms>(_GetPayrollParms);
			
			return iGetPayrollParmsExt;
		}
	}
}
