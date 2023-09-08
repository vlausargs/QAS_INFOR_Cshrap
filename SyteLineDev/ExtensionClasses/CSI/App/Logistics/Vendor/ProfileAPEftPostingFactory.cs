//PROJECT NAME: Logistics
//CLASS NAME: ProfileAPEftPostingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ProfileAPEftPostingFactory
	{
		public IProfileAPEftPosting Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileAPEftPosting = new Logistics.Vendor.ProfileAPEftPosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileAPEftPostingExt = timerfactory.Create<Logistics.Vendor.IProfileAPEftPosting>(_ProfileAPEftPosting);
			
			return iProfileAPEftPostingExt;
		}
	}
}
