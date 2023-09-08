//PROJECT NAME: Logistics
//CLASS NAME: ProfileAPCheckPrintingPostingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ProfileAPCheckPrintingPostingFactory
	{
		public IProfileAPCheckPrintingPosting Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileAPCheckPrintingPosting = new Logistics.Vendor.ProfileAPCheckPrintingPosting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileAPCheckPrintingPostingExt = timerfactory.Create<Logistics.Vendor.IProfileAPCheckPrintingPosting>(_ProfileAPCheckPrintingPosting);
			
			return iProfileAPCheckPrintingPostingExt;
		}
	}
}
