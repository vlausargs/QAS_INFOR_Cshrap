//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_TRRStatusSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_TRRStatusSSRSFactory
	{
		public IRpt_RSQC_TRRStatusSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_TRRStatusSSRS = new Reporting.Rpt_RSQC_TRRStatusSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_TRRStatusSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_TRRStatusSSRS>(_Rpt_RSQC_TRRStatusSSRS);
			
			return iRpt_RSQC_TRRStatusSSRSExt;
		}
	}
}
