//PROJECT NAME: Employee
//CLASS NAME: Rpt_SalariesByGenderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class Rpt_SalariesByGenderFactory
	{
		public IRpt_SalariesByGender Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SalariesByGender = new Employee.Rpt_SalariesByGender(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalariesByGenderExt = timerfactory.Create<Employee.IRpt_SalariesByGender>(_Rpt_SalariesByGender);
			
			return iRpt_SalariesByGenderExt;
		}
	}
}
