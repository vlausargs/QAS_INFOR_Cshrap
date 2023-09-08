//PROJECT NAME: Reporting
//CLASS NAME: RSQC_COCTestsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_COCTestsSSRSFactory
	{
		public IRSQC_COCTestsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_COCTestsSSRS = new Reporting.RSQC_COCTestsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_COCTestsSSRSExt = timerfactory.Create<Reporting.IRSQC_COCTestsSSRS>(_RSQC_COCTestsSSRS);
			
			return iRSQC_COCTestsSSRSExt;
		}
	}
}
