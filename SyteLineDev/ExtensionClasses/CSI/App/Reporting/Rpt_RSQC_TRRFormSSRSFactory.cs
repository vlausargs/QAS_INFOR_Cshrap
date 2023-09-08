//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_TRRFormSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_TRRFormSSRSFactory
	{
		public IRpt_RSQC_TRRFormSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_TRRFormSSRS = new Reporting.Rpt_RSQC_TRRFormSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_TRRFormSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_TRRFormSSRS>(_Rpt_RSQC_TRRFormSSRS);
			
			return iRpt_RSQC_TRRFormSSRSExt;
		}
	}
}
