//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_TransactionSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_TransactionSSRSFactory
	{
		public IRpt_RSQC_TransactionSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_TransactionSSRS = new Reporting.Rpt_RSQC_TransactionSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_TransactionSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_TransactionSSRS>(_Rpt_RSQC_TransactionSSRS);
			
			return iRpt_RSQC_TransactionSSRSExt;
		}
	}
}
