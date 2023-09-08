//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPOutsidePaperworkSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPOutsidePaperworkSSRSFactory
	{
		public IRpt_RSQC_IPOutsidePaperworkSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_IPOutsidePaperworkSSRS = new Reporting.Rpt_RSQC_IPOutsidePaperworkSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_IPOutsidePaperworkSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_IPOutsidePaperworkSSRS>(_Rpt_RSQC_IPOutsidePaperworkSSRS);
			
			return iRpt_RSQC_IPOutsidePaperworkSSRSExt;
		}
	}
}
