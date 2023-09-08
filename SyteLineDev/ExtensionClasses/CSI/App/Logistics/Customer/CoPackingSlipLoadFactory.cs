//PROJECT NAME: Logistics
//CLASS NAME: CoPackingSlipLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CoPackingSlipLoadFactory
	{
		public ICoPackingSlipLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CoPackingSlipLoad = new Logistics.Customer.CoPackingSlipLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoPackingSlipLoadExt = timerfactory.Create<Logistics.Customer.ICoPackingSlipLoad>(_CoPackingSlipLoad);
			
			return iCoPackingSlipLoadExt;
		}
	}
}
