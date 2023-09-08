//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryConsignedtoCustomerUsageFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InventoryConsignedtoCustomerUsageFactory
	{
		public IRpt_InventoryConsignedtoCustomerUsage Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InventoryConsignedtoCustomerUsage = new Reporting.Rpt_InventoryConsignedtoCustomerUsage(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InventoryConsignedtoCustomerUsageExt = timerfactory.Create<Reporting.IRpt_InventoryConsignedtoCustomerUsage>(_Rpt_InventoryConsignedtoCustomerUsage);
			
			return iRpt_InventoryConsignedtoCustomerUsageExt;
		}
	}
}
