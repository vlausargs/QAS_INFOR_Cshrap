//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_MRRFormSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_MRRFormSSRSFactory
	{
		public IRpt_RSQC_MRRFormSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_MRRFormSSRS = new Reporting.Rpt_RSQC_MRRFormSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_MRRFormSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_MRRFormSSRS>(_Rpt_RSQC_MRRFormSSRS);
			
			return iRpt_RSQC_MRRFormSSRSExt;
		}
	}
}
