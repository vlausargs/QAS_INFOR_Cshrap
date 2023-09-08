//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_MRRStatusSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_MRRStatusSSRSFactory
	{
		public IRpt_RSQC_MRRStatusSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_MRRStatusSSRS = new Reporting.Rpt_RSQC_MRRStatusSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_MRRStatusSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_MRRStatusSSRS>(_Rpt_RSQC_MRRStatusSSRS);
			
			return iRpt_RSQC_MRRStatusSSRSExt;
		}
	}
}
