//PROJECT NAME: Reporting
//CLASS NAME: RSQC_ShowCarTestsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_ShowCarTestsSSRSFactory
	{
		public IRSQC_ShowCarTestsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_ShowCarTestsSSRS = new Reporting.RSQC_ShowCarTestsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ShowCarTestsSSRSExt = timerfactory.Create<Reporting.IRSQC_ShowCarTestsSSRS>(_RSQC_ShowCarTestsSSRS);
			
			return iRSQC_ShowCarTestsSSRSExt;
		}
	}
}
