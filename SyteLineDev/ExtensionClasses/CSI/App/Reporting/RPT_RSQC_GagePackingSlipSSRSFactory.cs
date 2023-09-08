//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_GagePackingSlipSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_RSQC_GagePackingSlipSSRSFactory
	{
		public IRPT_RSQC_GagePackingSlipSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_RSQC_GagePackingSlipSSRS = new Reporting.RPT_RSQC_GagePackingSlipSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_RSQC_GagePackingSlipSSRSExt = timerfactory.Create<Reporting.IRPT_RSQC_GagePackingSlipSSRS>(_RPT_RSQC_GagePackingSlipSSRS);
			
			return iRPT_RSQC_GagePackingSlipSSRSExt;
		}
	}
}
