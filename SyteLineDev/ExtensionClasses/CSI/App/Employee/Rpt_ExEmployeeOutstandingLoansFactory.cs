//PROJECT NAME: Employee
//CLASS NAME: Rpt_ExEmployeeOutstandingLoansFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class Rpt_ExEmployeeOutstandingLoansFactory
	{
		public IRpt_ExEmployeeOutstandingLoans Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ExEmployeeOutstandingLoans = new Employee.Rpt_ExEmployeeOutstandingLoans(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ExEmployeeOutstandingLoansExt = timerfactory.Create<Employee.IRpt_ExEmployeeOutstandingLoans>(_Rpt_ExEmployeeOutstandingLoans);
			
			return iRpt_ExEmployeeOutstandingLoansExt;
		}
	}
}
