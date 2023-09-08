//PROJECT NAME: Reporting
//CLASS NAME: RSQC_PrintTagsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_PrintTagsSSRSFactory
	{
		public IRSQC_PrintTagsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_PrintTagsSSRS = new Reporting.RSQC_PrintTagsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_PrintTagsSSRSExt = timerfactory.Create<Reporting.IRSQC_PrintTagsSSRS>(_RSQC_PrintTagsSSRS);
			
			return iRSQC_PrintTagsSSRSExt;
		}
	}
}
