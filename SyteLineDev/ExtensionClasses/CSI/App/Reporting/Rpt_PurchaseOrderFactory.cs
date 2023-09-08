//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PurchaseOrderFactory
	{
		public IRpt_PurchaseOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PurchaseOrder = new Reporting.Rpt_PurchaseOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PurchaseOrderExt = timerfactory.Create<Reporting.IRpt_PurchaseOrder>(_Rpt_PurchaseOrder);
			
			return iRpt_PurchaseOrderExt;
		}
	}
}
