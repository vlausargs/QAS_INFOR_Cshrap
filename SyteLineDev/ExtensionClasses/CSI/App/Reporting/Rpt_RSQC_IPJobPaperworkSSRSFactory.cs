//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPJobPaperworkSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPJobPaperworkSSRSFactory
	{
		public IRpt_RSQC_IPJobPaperworkSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_IPJobPaperworkSSRS = new Reporting.Rpt_RSQC_IPJobPaperworkSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_IPJobPaperworkSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_IPJobPaperworkSSRS>(_Rpt_RSQC_IPJobPaperworkSSRS);
			
			return iRpt_RSQC_IPJobPaperworkSSRSExt;
		}
	}
}
