//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectedItemCompletionsbyResourceGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectedItemCompletionsbyResourceGroupFactory
	{
		public IRpt_ProjectedItemCompletionsbyResourceGroup Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectedItemCompletionsbyResourceGroup = new Reporting.Rpt_ProjectedItemCompletionsbyResourceGroup(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectedItemCompletionsbyResourceGroupExt = timerfactory.Create<Reporting.IRpt_ProjectedItemCompletionsbyResourceGroup>(_Rpt_ProjectedItemCompletionsbyResourceGroup);
			
			return iRpt_ProjectedItemCompletionsbyResourceGroupExt;
		}
	}
}
