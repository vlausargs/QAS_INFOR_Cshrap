//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_VRMAPendingSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_VRMAPendingSSRSFactory
	{
		public IRpt_RSQC_VRMAPendingSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_VRMAPendingSSRS = new Reporting.Rpt_RSQC_VRMAPendingSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_VRMAPendingSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_VRMAPendingSSRS>(_Rpt_RSQC_VRMAPendingSSRS);
			
			return iRpt_RSQC_VRMAPendingSSRSExt;
		}
	}
}
