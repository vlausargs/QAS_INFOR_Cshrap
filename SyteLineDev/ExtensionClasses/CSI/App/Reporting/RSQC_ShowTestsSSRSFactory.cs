//PROJECT NAME: Reporting
//CLASS NAME: RSQC_ShowTestsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_ShowTestsSSRSFactory
	{
		public IRSQC_ShowTestsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_ShowTestsSSRS = new Reporting.RSQC_ShowTestsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ShowTestsSSRSExt = timerfactory.Create<Reporting.IRSQC_ShowTestsSSRS>(_RSQC_ShowTestsSSRS);
			
			return iRSQC_ShowTestsSSRSExt;
		}
	}
}
