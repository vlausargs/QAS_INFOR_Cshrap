//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupVRMAStatusSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupVRMAStatusSSRSFactory
	{
		public IRpt_RSQC_SupVRMAStatusSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_SupVRMAStatusSSRS = new Reporting.Rpt_RSQC_SupVRMAStatusSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_SupVRMAStatusSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_SupVRMAStatusSSRS>(_Rpt_RSQC_SupVRMAStatusSSRS);
			
			return iRpt_RSQC_SupVRMAStatusSSRSExt;
		}
	}
}
