//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPYieldSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPYieldSSRSFactory
	{
		public IRpt_RSQC_IPYieldSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_IPYieldSSRS = new Reporting.Rpt_RSQC_IPYieldSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_IPYieldSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_IPYieldSSRS>(_Rpt_RSQC_IPYieldSSRS);
			
			return iRpt_RSQC_IPYieldSSRSExt;
		}
	}
}
