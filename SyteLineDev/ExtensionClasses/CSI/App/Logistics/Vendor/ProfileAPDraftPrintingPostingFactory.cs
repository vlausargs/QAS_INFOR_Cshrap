//PROJECT NAME: Logistics
//CLASS NAME: ProfileAPDraftPrintingPostingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ProfileAPDraftPrintingPostingFactory
	{
		public IProfileAPDraftPrintingPosting Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileAPDraftPrintingPosting = new Logistics.Vendor.ProfileAPDraftPrintingPosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileAPDraftPrintingPostingExt = timerfactory.Create<Logistics.Vendor.IProfileAPDraftPrintingPosting>(_ProfileAPDraftPrintingPosting);
			
			return iProfileAPDraftPrintingPostingExt;
		}
	}
}
