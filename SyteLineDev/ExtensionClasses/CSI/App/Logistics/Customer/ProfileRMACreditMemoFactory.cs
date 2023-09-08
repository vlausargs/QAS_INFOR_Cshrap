//PROJECT NAME: Logistics
//CLASS NAME: ProfileRMACreditMemoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileRMACreditMemoFactory
	{
		public IProfileRMACreditMemo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileRMACreditMemo = new Logistics.Customer.ProfileRMACreditMemo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileRMACreditMemoExt = timerfactory.Create<Logistics.Customer.IProfileRMACreditMemo>(_ProfileRMACreditMemo);
			
			return iProfileRMACreditMemoExt;
		}
	}
}
