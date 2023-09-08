//PROJECT NAME: Logistics
//CLASS NAME: PurgePackingSlipRegisterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class PurgePackingSlipRegisterFactory
	{
		public IPurgePackingSlipRegister Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PurgePackingSlipRegister = new Logistics.Customer.PurgePackingSlipRegister(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgePackingSlipRegisterExt = timerfactory.Create<Logistics.Customer.IPurgePackingSlipRegister>(_PurgePackingSlipRegister);
			
			return iPurgePackingSlipRegisterExt;
		}
	}
}
