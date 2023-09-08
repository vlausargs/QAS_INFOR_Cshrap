//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InboundPurchaseOrderErrorFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InboundPurchaseOrderErrorFactory
	{
		public IRpt_InboundPurchaseOrderError Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InboundPurchaseOrderError = new Reporting.Rpt_InboundPurchaseOrderError(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InboundPurchaseOrderErrorExt = timerfactory.Create<Reporting.IRpt_InboundPurchaseOrderError>(_Rpt_InboundPurchaseOrderError);
			
			return iRpt_InboundPurchaseOrderErrorExt;
		}
	}
}
