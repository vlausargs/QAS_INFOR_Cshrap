//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleOperationStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleOperationStatusFactory
	{
		public IRpt_ProductionScheduleOperationStatus Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProductionScheduleOperationStatus = new Reporting.Rpt_ProductionScheduleOperationStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProductionScheduleOperationStatusExt = timerfactory.Create<Reporting.IRpt_ProductionScheduleOperationStatus>(_Rpt_ProductionScheduleOperationStatus);
			
			return iRpt_ProductionScheduleOperationStatusExt;
		}
	}
}
