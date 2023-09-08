//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupReadyForReceiptsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupReadyForReceiptsSSRSFactory
	{
		public IRpt_RSQC_SupReadyForReceiptsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_SupReadyForReceiptsSSRS = new Reporting.Rpt_RSQC_SupReadyForReceiptsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_SupReadyForReceiptsSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_SupReadyForReceiptsSSRS>(_Rpt_RSQC_SupReadyForReceiptsSSRS);
			
			return iRpt_RSQC_SupReadyForReceiptsSSRSExt;
		}
	}
}
