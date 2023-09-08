//PROJECT NAME: Logistics
//CLASS NAME: CLM_ChangeVendorContractPriceStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_ChangeVendorContractPriceStatusFactory
	{
		public ICLM_ChangeVendorContractPriceStatus Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ChangeVendorContractPriceStatus = new Logistics.Vendor.CLM_ChangeVendorContractPriceStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ChangeVendorContractPriceStatusExt = timerfactory.Create<Logistics.Vendor.ICLM_ChangeVendorContractPriceStatus>(_CLM_ChangeVendorContractPriceStatus);
			
			return iCLM_ChangeVendorContractPriceStatusExt;
		}
	}
}
