//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EDIPurchaseOrderStatusFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EDIPurchaseOrderStatusFactory
	{
		public IRpt_EDIPurchaseOrderStatus Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EDIPurchaseOrderStatus = new Reporting.Rpt_EDIPurchaseOrderStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EDIPurchaseOrderStatusExt = timerfactory.Create<Reporting.IRpt_EDIPurchaseOrderStatus>(_Rpt_EDIPurchaseOrderStatus);
			
			return iRpt_EDIPurchaseOrderStatusExt;
		}
	}
}
