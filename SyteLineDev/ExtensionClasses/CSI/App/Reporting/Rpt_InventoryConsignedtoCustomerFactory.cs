//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryConsignedtoCustomerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InventoryConsignedtoCustomerFactory
	{
		public IRpt_InventoryConsignedtoCustomer Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InventoryConsignedtoCustomer = new Reporting.Rpt_InventoryConsignedtoCustomer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InventoryConsignedtoCustomerExt = timerfactory.Create<Reporting.IRpt_InventoryConsignedtoCustomer>(_Rpt_InventoryConsignedtoCustomer);
			
			return iRpt_InventoryConsignedtoCustomerExt;
		}
	}
}
