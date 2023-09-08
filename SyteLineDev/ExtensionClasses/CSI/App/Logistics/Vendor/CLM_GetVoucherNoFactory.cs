//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetVoucherNoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_GetVoucherNoFactory
	{
		public ICLM_GetVoucherNo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetVoucherNo = new Logistics.Vendor.CLM_GetVoucherNo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetVoucherNoExt = timerfactory.Create<Logistics.Vendor.ICLM_GetVoucherNo>(_CLM_GetVoucherNo);
			
			return iCLM_GetVoucherNoExt;
		}
	}
}
