//PROJECT NAME: Employee
//CLASS NAME: GetApplicantDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class GetApplicantDataFactory
	{
		public IGetApplicantData Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetApplicantData = new Employee.GetApplicantData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetApplicantDataExt = timerfactory.Create<Employee.IGetApplicantData>(_GetApplicantData);
			
			return iGetApplicantDataExt;
		}
	}
}
