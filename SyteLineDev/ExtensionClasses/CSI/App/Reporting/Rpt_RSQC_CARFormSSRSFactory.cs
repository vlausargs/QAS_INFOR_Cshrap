//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CARFormSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CARFormSSRSFactory
	{
		public IRpt_RSQC_CARFormSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CARFormSSRS = new Reporting.Rpt_RSQC_CARFormSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CARFormSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CARFormSSRS>(_Rpt_RSQC_CARFormSSRS);
			
			return iRpt_RSQC_CARFormSSRSExt;
		}
	}
}
