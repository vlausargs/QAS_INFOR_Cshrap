//PROJECT NAME: Logistics
//CLASS NAME: ProfileAPWirePostingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ProfileAPWirePostingFactory
	{
		public IProfileAPWirePosting Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileAPWirePosting = new Logistics.Vendor.ProfileAPWirePosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileAPWirePostingExt = timerfactory.Create<Logistics.Vendor.IProfileAPWirePosting>(_ProfileAPWirePosting);
			
			return iProfileAPWirePostingExt;
		}
	}
}
