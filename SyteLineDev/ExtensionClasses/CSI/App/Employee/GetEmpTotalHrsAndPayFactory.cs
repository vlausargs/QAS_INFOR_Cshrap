//PROJECT NAME: CSIEmployee
//CLASS NAME: GetEmpTotalHrsAndPayFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class GetEmpTotalHrsAndPayFactory
	{
		public IGetEmpTotalHrsAndPay Create(IApplicationDB appDB)
		{
			var _GetEmpTotalHrsAndPay = new Employee.GetEmpTotalHrsAndPay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetEmpTotalHrsAndPayExt = timerfactory.Create<Employee.IGetEmpTotalHrsAndPay>(_GetEmpTotalHrsAndPay);
			
			return iGetEmpTotalHrsAndPayExt;
		}
	}
}
