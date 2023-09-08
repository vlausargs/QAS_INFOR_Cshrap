//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupVendorPPMSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupVendorPPMSSRSFactory
	{
		public IRpt_RSQC_SupVendorPPMSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_SupVendorPPMSSRS = new Reporting.Rpt_RSQC_SupVendorPPMSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_SupVendorPPMSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_SupVendorPPMSSRS>(_Rpt_RSQC_SupVendorPPMSSRS);
			
			return iRpt_RSQC_SupVendorPPMSSRSExt;
		}
	}
}
