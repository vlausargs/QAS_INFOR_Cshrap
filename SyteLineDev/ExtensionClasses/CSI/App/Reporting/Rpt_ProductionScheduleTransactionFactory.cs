//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleTransactionFactory
	{
		public IRpt_ProductionScheduleTransaction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProductionScheduleTransaction = new Reporting.Rpt_ProductionScheduleTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProductionScheduleTransactionExt = timerfactory.Create<Reporting.IRpt_ProductionScheduleTransaction>(_Rpt_ProductionScheduleTransaction);
			
			return iRpt_ProductionScheduleTransactionExt;
		}
	}
}
