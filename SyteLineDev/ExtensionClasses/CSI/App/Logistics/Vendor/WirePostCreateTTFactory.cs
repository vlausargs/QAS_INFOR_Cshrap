//PROJECT NAME: Logistics
//CLASS NAME: WirePostCreateTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class WirePostCreateTTFactory
	{
		public IWirePostCreateTT Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _WirePostCreateTT = new Logistics.Vendor.WirePostCreateTT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWirePostCreateTTExt = timerfactory.Create<Logistics.Vendor.IWirePostCreateTT>(_WirePostCreateTT);
			
			return iWirePostCreateTTExt;
		}
	}
}
