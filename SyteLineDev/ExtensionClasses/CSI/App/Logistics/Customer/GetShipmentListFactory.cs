//PROJECT NAME: Logistics
//CLASS NAME: GetShipmentListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class GetShipmentListFactory
	{
		public IGetShipmentList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetShipmentList = new Logistics.Customer.GetShipmentList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetShipmentListExt = timerfactory.Create<Logistics.Customer.IGetShipmentList>(_GetShipmentList);
			
			return iGetShipmentListExt;
		}
	}
}
