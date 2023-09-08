//PROJECT NAME: Reporting
//CLASS NAME: THARpt_PCPaymentTransactionReprintFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_PCPaymentTransactionReprintFactory
	{
		public ITHARpt_PCPaymentTransactionReprint Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_PCPaymentTransactionReprint = new Reporting.THARpt_PCPaymentTransactionReprint(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_PCPaymentTransactionReprintExt = timerfactory.Create<Reporting.ITHARpt_PCPaymentTransactionReprint>(_THARpt_PCPaymentTransactionReprint);
			
			return iTHARpt_PCPaymentTransactionReprintExt;
		}
	}
}
