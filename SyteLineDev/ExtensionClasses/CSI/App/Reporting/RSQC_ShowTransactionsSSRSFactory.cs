//PROJECT NAME: Reporting
//CLASS NAME: RSQC_ShowTransactionsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_ShowTransactionsSSRSFactory
	{
		public IRSQC_ShowTransactionsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_ShowTransactionsSSRS = new Reporting.RSQC_ShowTransactionsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ShowTransactionsSSRSExt = timerfactory.Create<Reporting.IRSQC_ShowTransactionsSSRS>(_RSQC_ShowTransactionsSSRS);
			
			return iRSQC_ShowTransactionsSSRSExt;
		}
	}
}
