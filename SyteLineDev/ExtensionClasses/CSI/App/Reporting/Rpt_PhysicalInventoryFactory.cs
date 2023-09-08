//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PhysicalInventoryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PhysicalInventoryFactory
	{
		public IRpt_PhysicalInventory Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PhysicalInventory = new Reporting.Rpt_PhysicalInventory(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PhysicalInventoryExt = timerfactory.Create<Reporting.IRpt_PhysicalInventory>(_Rpt_PhysicalInventory);
			
			return iRpt_PhysicalInventoryExt;
		}
	}
}
