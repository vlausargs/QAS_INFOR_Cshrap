//PROJECT NAME: Logistics
//CLASS NAME: ARFinChgPostCreateTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ARFinChgPostCreateTTFactory
	{
		public IARFinChgPostCreateTT Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ARFinChgPostCreateTT = new Logistics.Customer.ARFinChgPostCreateTT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARFinChgPostCreateTTExt = timerfactory.Create<Logistics.Customer.IARFinChgPostCreateTT>(_ARFinChgPostCreateTT);
			
			return iARFinChgPostCreateTTExt;
		}
	}
}
