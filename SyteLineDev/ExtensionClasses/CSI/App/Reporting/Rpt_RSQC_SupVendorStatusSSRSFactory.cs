//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupVendorStatusSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupVendorStatusSSRSFactory
	{
		public IRpt_RSQC_SupVendorStatusSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_SupVendorStatusSSRS = new Reporting.Rpt_RSQC_SupVendorStatusSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_SupVendorStatusSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_SupVendorStatusSSRS>(_Rpt_RSQC_SupVendorStatusSSRS);
			
			return iRpt_RSQC_SupVendorStatusSSRSExt;
		}
	}
}
