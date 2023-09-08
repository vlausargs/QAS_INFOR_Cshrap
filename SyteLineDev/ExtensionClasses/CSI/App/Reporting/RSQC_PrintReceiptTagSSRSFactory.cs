//PROJECT NAME: Reporting
//CLASS NAME: RSQC_PrintReceiptTagSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_PrintReceiptTagSSRSFactory
	{
		public IRSQC_PrintReceiptTagSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_PrintReceiptTagSSRS = new Reporting.RSQC_PrintReceiptTagSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_PrintReceiptTagSSRSExt = timerfactory.Create<Reporting.IRSQC_PrintReceiptTagSSRS>(_RSQC_PrintReceiptTagSSRS);
			
			return iRSQC_PrintReceiptTagSSRSExt;
		}
	}
}
