//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OutboundPurchaseOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_OutboundPurchaseOrderFactory
	{
		public IRpt_OutboundPurchaseOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_OutboundPurchaseOrder = new Reporting.Rpt_OutboundPurchaseOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_OutboundPurchaseOrderExt = timerfactory.Create<Reporting.IRpt_OutboundPurchaseOrder>(_Rpt_OutboundPurchaseOrder);
			
			return iRpt_OutboundPurchaseOrderExt;
		}
	}
}
