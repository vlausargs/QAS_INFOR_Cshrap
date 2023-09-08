//PROJECT NAME: Logistics
//CLASS NAME: CLM_AppmtChecksToVoidFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_AppmtChecksToVoidFactory
	{
		public ICLM_AppmtChecksToVoid Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_AppmtChecksToVoid = new Logistics.Vendor.CLM_AppmtChecksToVoid(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_AppmtChecksToVoidExt = timerfactory.Create<Logistics.Vendor.ICLM_AppmtChecksToVoid>(_CLM_AppmtChecksToVoid);
			
			return iCLM_AppmtChecksToVoidExt;
		}
	}
}
