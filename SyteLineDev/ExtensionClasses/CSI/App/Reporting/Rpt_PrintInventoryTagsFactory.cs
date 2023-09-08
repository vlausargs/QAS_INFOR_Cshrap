//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintInventoryTagsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PrintInventoryTagsFactory
	{
		public IRpt_PrintInventoryTags Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PrintInventoryTags = new Reporting.Rpt_PrintInventoryTags(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PrintInventoryTagsExt = timerfactory.Create<Reporting.IRpt_PrintInventoryTags>(_Rpt_PrintInventoryTags);
			
			return iRpt_PrintInventoryTagsExt;
		}
	}
}
