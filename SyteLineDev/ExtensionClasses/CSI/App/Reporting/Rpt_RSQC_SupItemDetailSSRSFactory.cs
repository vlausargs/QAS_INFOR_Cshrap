//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupItemDetailSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupItemDetailSSRSFactory
	{
		public IRpt_RSQC_SupItemDetailSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_SupItemDetailSSRS = new Reporting.Rpt_RSQC_SupItemDetailSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_SupItemDetailSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_SupItemDetailSSRS>(_Rpt_RSQC_SupItemDetailSSRS);
			
			return iRpt_RSQC_SupItemDetailSSRSExt;
		}
	}
}
