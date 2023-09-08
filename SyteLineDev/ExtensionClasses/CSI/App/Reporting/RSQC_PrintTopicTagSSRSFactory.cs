//PROJECT NAME: Reporting
//CLASS NAME: RSQC_PrintTopicTagSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_PrintTopicTagSSRSFactory
	{
		public IRSQC_PrintTopicTagSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_PrintTopicTagSSRS = new Reporting.RSQC_PrintTopicTagSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_PrintTopicTagSSRSExt = timerfactory.Create<Reporting.IRSQC_PrintTopicTagSSRS>(_RSQC_PrintTopicTagSSRS);
			
			return iRSQC_PrintTopicTagSSRSExt;
		}
	}
}
