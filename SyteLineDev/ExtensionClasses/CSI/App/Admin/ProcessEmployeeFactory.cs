//PROJECT NAME: Admin
//CLASS NAME: ProcessEmployeeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class ProcessEmployeeFactory
	{
		public IProcessEmployee Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProcessEmployee = new Admin.ProcessEmployee(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessEmployeeExt = timerfactory.Create<Admin.IProcessEmployee>(_ProcessEmployee);
			
			return iProcessEmployeeExt;
		}
	}
}
