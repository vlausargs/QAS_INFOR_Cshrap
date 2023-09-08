//PROJECT NAME: Employee
//CLASS NAME: HrYearEndFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class HrYearEndFactory
	{
		public IHrYearEnd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _HrYearEnd = new Employee.HrYearEnd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHrYearEndExt = timerfactory.Create<Employee.IHrYearEnd>(_HrYearEnd);
			
			return iHrYearEndExt;
		}
	}
}
