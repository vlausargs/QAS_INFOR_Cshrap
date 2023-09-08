//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseOrderVariancebyItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PurchaseOrderVariancebyItemFactory
	{
		public IRpt_PurchaseOrderVariancebyItem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PurchaseOrderVariancebyItem = new Reporting.Rpt_PurchaseOrderVariancebyItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PurchaseOrderVariancebyItemExt = timerfactory.Create<Reporting.IRpt_PurchaseOrderVariancebyItem>(_Rpt_PurchaseOrderVariancebyItem);
			
			return iRpt_PurchaseOrderVariancebyItemExt;
		}
	}
}
