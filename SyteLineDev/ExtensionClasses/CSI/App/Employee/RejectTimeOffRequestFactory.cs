//PROJECT NAME: Employee
//CLASS NAME: RejectTimeOffRequestFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class RejectTimeOffRequestFactory
	{
		public IRejectTimeOffRequest Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RejectTimeOffRequest = new Employee.RejectTimeOffRequest(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRejectTimeOffRequestExt = timerfactory.Create<Employee.IRejectTimeOffRequest>(_RejectTimeOffRequest);
			
			return iRejectTimeOffRequestExt;
		}
	}
}
