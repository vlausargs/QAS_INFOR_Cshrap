//PROJECT NAME: CSIEmployee
//CLASS NAME: CreateTimeOffRequestFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class CreateTimeOffRequestFactory
	{
		public ICreateTimeOffRequest Create(IApplicationDB appDB)
		{
			var _CreateTimeOffRequest = new Employee.CreateTimeOffRequest(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateTimeOffRequestExt = timerfactory.Create<Employee.ICreateTimeOffRequest>(_CreateTimeOffRequest);
			
			return iCreateTimeOffRequestExt;
		}
	}
}
