//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPQualityPlanSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPQualityPlanSSRSFactory
	{
		public IRpt_RSQC_IPQualityPlanSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_IPQualityPlanSSRS = new Reporting.Rpt_RSQC_IPQualityPlanSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_IPQualityPlanSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_IPQualityPlanSSRS>(_Rpt_RSQC_IPQualityPlanSSRS);
			
			return iRpt_RSQC_IPQualityPlanSSRSExt;
		}
	}
}
