//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CCRStatusSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CCRStatusSSRSFactory
	{
		public IRpt_RSQC_CCRStatusSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CCRStatusSSRS = new Reporting.Rpt_RSQC_CCRStatusSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CCRStatusSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CCRStatusSSRS>(_Rpt_RSQC_CCRStatusSSRS);
			
			return iRpt_RSQC_CCRStatusSSRSExt;
		}
	}
}
