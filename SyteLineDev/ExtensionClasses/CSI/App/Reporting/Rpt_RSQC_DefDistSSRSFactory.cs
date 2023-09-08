//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_DefDistSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_DefDistSSRSFactory
	{
		public IRpt_RSQC_DefDistSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_DefDistSSRS = new Reporting.Rpt_RSQC_DefDistSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_DefDistSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_DefDistSSRS>(_Rpt_RSQC_DefDistSSRS);
			
			return iRpt_RSQC_DefDistSSRSExt;
		}
	}
}
