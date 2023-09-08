//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerOrdersforReservableItemsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CustomerOrdersforReservableItemsFactory
	{
		public IRpt_CustomerOrdersforReservableItems Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CustomerOrdersforReservableItems = new Reporting.Rpt_CustomerOrdersforReservableItems(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CustomerOrdersforReservableItemsExt = timerfactory.Create<Reporting.IRpt_CustomerOrdersforReservableItems>(_Rpt_CustomerOrdersforReservableItems);
			
			return iRpt_CustomerOrdersforReservableItemsExt;
		}
	}
}
