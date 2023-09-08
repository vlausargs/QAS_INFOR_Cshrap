//PROJECT NAME: Reporting
//CLASS NAME: RSQC_PrintChangeTagFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_PrintChangeTagFactory
	{
		public IRSQC_PrintChangeTag Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_PrintChangeTag = new Reporting.RSQC_PrintChangeTag(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_PrintChangeTagExt = timerfactory.Create<Reporting.IRSQC_PrintChangeTag>(_RSQC_PrintChangeTag);
			
			return iRSQC_PrintChangeTagExt;
		}
	}
}
