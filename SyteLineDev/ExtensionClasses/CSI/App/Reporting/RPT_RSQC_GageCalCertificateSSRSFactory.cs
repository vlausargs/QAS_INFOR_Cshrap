//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_GageCalCertificateSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_RSQC_GageCalCertificateSSRSFactory
	{
		public IRPT_RSQC_GageCalCertificateSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_RSQC_GageCalCertificateSSRS = new Reporting.RPT_RSQC_GageCalCertificateSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_RSQC_GageCalCertificateSSRSExt = timerfactory.Create<Reporting.IRPT_RSQC_GageCalCertificateSSRS>(_RPT_RSQC_GageCalCertificateSSRS);
			
			return iRPT_RSQC_GageCalCertificateSSRSExt;
		}
	}
}
