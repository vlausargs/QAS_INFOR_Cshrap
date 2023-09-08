//PROJECT NAME: Logistics
//CLASS NAME: VchAuthFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class VchAuthFactory
	{
		public IVchAuth Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _VchAuth = new Logistics.Vendor.VchAuth(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVchAuthExt = timerfactory.Create<Logistics.Vendor.IVchAuth>(_VchAuth);
			
			return iVchAuthExt;
		}
	}
}
