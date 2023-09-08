//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupVRMAFormSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupVRMAFormSSRSFactory
	{
		public IRpt_RSQC_SupVRMAFormSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_SupVRMAFormSSRS = new Reporting.Rpt_RSQC_SupVRMAFormSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_SupVRMAFormSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_SupVRMAFormSSRS>(_Rpt_RSQC_SupVRMAFormSSRS);
			
			return iRpt_RSQC_SupVRMAFormSSRSExt;
		}
	}
}
