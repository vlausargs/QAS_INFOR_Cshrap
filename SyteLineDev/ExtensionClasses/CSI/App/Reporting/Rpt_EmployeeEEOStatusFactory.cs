//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EmployeeEEOStatusFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EmployeeEEOStatusFactory
	{
		public IRpt_EmployeeEEOStatus Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EmployeeEEOStatus = new Reporting.Rpt_EmployeeEEOStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EmployeeEEOStatusExt = timerfactory.Create<Reporting.IRpt_EmployeeEEOStatus>(_Rpt_EmployeeEEOStatus);
			
			return iRpt_EmployeeEEOStatusExt;
		}
	}
}
