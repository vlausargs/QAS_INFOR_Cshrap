//PROJECT NAME: Reporting
//CLASS NAME: RSQC_ReprintTagsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_ReprintTagsSSRSFactory
	{
		public IRSQC_ReprintTagsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_ReprintTagsSSRS = new Reporting.RSQC_ReprintTagsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ReprintTagsSSRSExt = timerfactory.Create<Reporting.IRSQC_ReprintTagsSSRS>(_RSQC_ReprintTagsSSRS);
			
			return iRSQC_ReprintTagsSSRSExt;
		}
	}
}
