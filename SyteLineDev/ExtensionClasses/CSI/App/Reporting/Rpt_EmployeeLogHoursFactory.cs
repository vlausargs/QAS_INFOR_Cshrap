//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EmployeeLogHoursFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EmployeeLogHoursFactory
	{
		public IRpt_EmployeeLogHours Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EmployeeLogHours = new Reporting.Rpt_EmployeeLogHours(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EmployeeLogHoursExt = timerfactory.Create<Reporting.IRpt_EmployeeLogHours>(_Rpt_EmployeeLogHours);
			
			return iRpt_EmployeeLogHoursExt;
		}
	}
}
