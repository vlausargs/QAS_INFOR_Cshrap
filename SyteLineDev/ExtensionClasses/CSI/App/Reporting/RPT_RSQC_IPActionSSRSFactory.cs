//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_IPActionSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_RSQC_IPActionSSRSFactory
	{
		public IRPT_RSQC_IPActionSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_RSQC_IPActionSSRS = new Reporting.RPT_RSQC_IPActionSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_RSQC_IPActionSSRSExt = timerfactory.Create<Reporting.IRPT_RSQC_IPActionSSRS>(_RPT_RSQC_IPActionSSRS);
			
			return iRPT_RSQC_IPActionSSRSExt;
		}
	}
}
