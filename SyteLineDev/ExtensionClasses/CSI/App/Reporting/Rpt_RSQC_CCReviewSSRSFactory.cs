//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CCReviewSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CCReviewSSRSFactory
	{
		public IRpt_RSQC_CCReviewSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CCReviewSSRS = new Reporting.Rpt_RSQC_CCReviewSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CCReviewSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CCReviewSSRS>(_Rpt_RSQC_CCReviewSSRS);
			
			return iRpt_RSQC_CCReviewSSRSExt;
		}
	}
}
