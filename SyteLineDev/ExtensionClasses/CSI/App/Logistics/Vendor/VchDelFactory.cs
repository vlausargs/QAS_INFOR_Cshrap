//PROJECT NAME: Logistics
//CLASS NAME: VchDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class VchDelFactory
	{
		public IVchDel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _VchDel = new Logistics.Vendor.VchDel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVchDelExt = timerfactory.Create<Logistics.Vendor.IVchDel>(_VchDel);
			
			return iVchDelExt;
		}
	}
}
