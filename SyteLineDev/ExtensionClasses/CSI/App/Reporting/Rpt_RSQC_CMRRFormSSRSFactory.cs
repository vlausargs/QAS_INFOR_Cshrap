//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CMRRFormSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CMRRFormSSRSFactory
	{
		public IRpt_RSQC_CMRRFormSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CMRRFormSSRS = new Reporting.Rpt_RSQC_CMRRFormSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CMRRFormSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CMRRFormSSRS>(_Rpt_RSQC_CMRRFormSSRS);
			
			return iRpt_RSQC_CMRRFormSSRSExt;
		}
	}
}
