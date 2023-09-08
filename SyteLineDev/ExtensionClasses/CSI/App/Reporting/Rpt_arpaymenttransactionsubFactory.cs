//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARPaymentTransactionSubFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ARPaymentTransactionSubFactory
	{
		public IRpt_ARPaymentTransactionSub Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARPaymentTransactionSub = new Reporting.Rpt_ARPaymentTransactionSub(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARPaymentTransactionSubExt = timerfactory.Create<Reporting.IRpt_ARPaymentTransactionSub>(_Rpt_ARPaymentTransactionSub);
			
			return iRpt_ARPaymentTransactionSubExt;
		}
	}
}
