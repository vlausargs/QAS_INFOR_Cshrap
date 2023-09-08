//PROJECT NAME: Logistics
//CLASS NAME: ProfileVendorStatementofAccountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ProfileVendorStatementofAccountFactory
	{
		public IProfileVendorStatementofAccount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileVendorStatementofAccount = new Logistics.Vendor.ProfileVendorStatementofAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileVendorStatementofAccountExt = timerfactory.Create<Logistics.Vendor.IProfileVendorStatementofAccount>(_ProfileVendorStatementofAccount);
			
			return iProfileVendorStatementofAccountExt;
		}
	}
}
