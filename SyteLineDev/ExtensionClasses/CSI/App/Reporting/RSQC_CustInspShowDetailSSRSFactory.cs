//PROJECT NAME: Reporting
//CLASS NAME: RSQC_CustInspShowDetailSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_CustInspShowDetailSSRSFactory
	{
		public IRSQC_CustInspShowDetailSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_CustInspShowDetailSSRS = new Reporting.RSQC_CustInspShowDetailSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CustInspShowDetailSSRSExt = timerfactory.Create<Reporting.IRSQC_CustInspShowDetailSSRS>(_RSQC_CustInspShowDetailSSRS);
			
			return iRSQC_CustInspShowDetailSSRSExt;
		}
	}
}
