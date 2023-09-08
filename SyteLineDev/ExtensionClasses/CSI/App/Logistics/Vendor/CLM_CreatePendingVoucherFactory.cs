//PROJECT NAME: Logistics
//CLASS NAME: CLM_CreatePendingVoucherFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_CreatePendingVoucherFactory
	{
		public ICLM_CreatePendingVoucher Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CreatePendingVoucher = new Logistics.Vendor.CLM_CreatePendingVoucher(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CreatePendingVoucherExt = timerfactory.Create<Logistics.Vendor.ICLM_CreatePendingVoucher>(_CLM_CreatePendingVoucher);
			
			return iCLM_CreatePendingVoucherExt;
		}
	}
}
