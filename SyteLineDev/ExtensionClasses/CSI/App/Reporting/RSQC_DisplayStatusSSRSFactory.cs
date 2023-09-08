//PROJECT NAME: Reporting
//CLASS NAME: RSQC_DisplayStatusSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_DisplayStatusSSRSFactory
	{
		public IRSQC_DisplayStatusSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_DisplayStatusSSRS = new Reporting.RSQC_DisplayStatusSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_DisplayStatusSSRSExt = timerfactory.Create<Reporting.IRSQC_DisplayStatusSSRS>(_RSQC_DisplayStatusSSRS);
			
			return iRSQC_DisplayStatusSSRSExt;
		}
	}
}
