//PROJECT NAME: Reporting
//CLASS NAME: RSQC_ShowCARCostsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_ShowCARCostsSSRSFactory
	{
		public IRSQC_ShowCARCostsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_ShowCARCostsSSRS = new Reporting.RSQC_ShowCARCostsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ShowCARCostsSSRSExt = timerfactory.Create<Reporting.IRSQC_ShowCARCostsSSRS>(_RSQC_ShowCARCostsSSRS);
			
			return iRSQC_ShowCARCostsSSRSExt;
		}
	}
}
