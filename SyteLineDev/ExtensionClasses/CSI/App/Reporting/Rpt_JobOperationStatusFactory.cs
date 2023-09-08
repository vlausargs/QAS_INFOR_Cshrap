//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobOperationStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobOperationStatusFactory
	{
		public IRpt_JobOperationStatus Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobOperationStatus = new Reporting.Rpt_JobOperationStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobOperationStatusExt = timerfactory.Create<Reporting.IRpt_JobOperationStatus>(_Rpt_JobOperationStatus);
			
			return iRpt_JobOperationStatusExt;
		}
	}
}
