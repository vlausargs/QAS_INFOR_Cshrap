//PROJECT NAME: Logistics
//CLASS NAME: APVchPostPopulateTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class APVchPostPopulateTTFactory
	{
		public IAPVchPostPopulateTT Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _APVchPostPopulateTT = new Logistics.Vendor.APVchPostPopulateTT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAPVchPostPopulateTTExt = timerfactory.Create<Logistics.Vendor.IAPVchPostPopulateTT>(_APVchPostPopulateTT);
			
			return iAPVchPostPopulateTTExt;
		}
	}
}
