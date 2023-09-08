//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPCostOfQualitySSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPCostOfQualitySSRSFactory
	{
		public IRpt_RSQC_IPCostOfQualitySSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_IPCostOfQualitySSRS = new Reporting.Rpt_RSQC_IPCostOfQualitySSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_IPCostOfQualitySSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_IPCostOfQualitySSRS>(_Rpt_RSQC_IPCostOfQualitySSRS);
			
			return iRpt_RSQC_IPCostOfQualitySSRSExt;
		}
	}
}
