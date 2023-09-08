//PROJECT NAME: Production
//CLASS NAME: Rpt_WorkCenterTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class Rpt_WorkCenterTransactionFactory
	{
		public IRpt_WorkCenterTransaction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_WorkCenterTransaction = new Production.Rpt_WorkCenterTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_WorkCenterTransactionExt = timerfactory.Create<Production.IRpt_WorkCenterTransaction>(_Rpt_WorkCenterTransaction);
			
			return iRpt_WorkCenterTransactionExt;
		}
	}
}
