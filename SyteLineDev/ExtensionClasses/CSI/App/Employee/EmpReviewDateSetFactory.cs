//PROJECT NAME: Employee
//CLASS NAME: EmpReviewDateSetFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class EmpReviewDateSetFactory
	{
		public IEmpReviewDateSet Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EmpReviewDateSet = new Employee.EmpReviewDateSet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEmpReviewDateSetExt = timerfactory.Create<Employee.IEmpReviewDateSet>(_EmpReviewDateSet);
			
			return iEmpReviewDateSetExt;
		}
	}
}
