//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CARStatusSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CARStatusSSRSFactory
	{
		public IRpt_RSQC_CARStatusSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CARStatusSSRS = new Reporting.Rpt_RSQC_CARStatusSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CARStatusSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CARStatusSSRS>(_Rpt_RSQC_CARStatusSSRS);
			
			return iRpt_RSQC_CARStatusSSRSExt;
		}
	}
}
