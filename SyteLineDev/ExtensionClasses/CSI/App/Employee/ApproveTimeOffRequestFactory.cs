//PROJECT NAME: CSIEmployee
//CLASS NAME: ApproveTimeOffRequestFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class ApproveTimeOffRequestFactory
	{
		public IApproveTimeOffRequest Create(IApplicationDB appDB)
		{
			var _ApproveTimeOffRequest = new Employee.ApproveTimeOffRequest(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApproveTimeOffRequestExt = timerfactory.Create<Employee.IApproveTimeOffRequest>(_ApproveTimeOffRequest);
			
			return iApproveTimeOffRequestExt;
		}
	}
}
