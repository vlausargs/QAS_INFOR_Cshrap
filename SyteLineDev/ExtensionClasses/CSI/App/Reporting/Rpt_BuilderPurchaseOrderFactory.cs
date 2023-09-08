//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BuilderPurchaseOrderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_BuilderPurchaseOrderFactory
	{
		public IRpt_BuilderPurchaseOrder Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_BuilderPurchaseOrder = new Reporting.Rpt_BuilderPurchaseOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_BuilderPurchaseOrderExt = timerfactory.Create<Reporting.IRpt_BuilderPurchaseOrder>(_Rpt_BuilderPurchaseOrder);
			
			return iRpt_BuilderPurchaseOrderExt;
		}
	}
}
