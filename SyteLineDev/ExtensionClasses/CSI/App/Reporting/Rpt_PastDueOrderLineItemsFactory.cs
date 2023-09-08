//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PastDueOrderLineItemsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PastDueOrderLineItemsFactory
	{
		public IRpt_PastDueOrderLineItems Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PastDueOrderLineItems = new Reporting.Rpt_PastDueOrderLineItems(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PastDueOrderLineItemsExt = timerfactory.Create<Reporting.IRpt_PastDueOrderLineItems>(_Rpt_PastDueOrderLineItems);
			
			return iRpt_PastDueOrderLineItemsExt;
		}
	}
}
