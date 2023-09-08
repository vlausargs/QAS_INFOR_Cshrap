//PROJECT NAME: Reporting
//CLASS NAME: SSSRMXRpt_VendorPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSRMXRpt_VendorPackingSlipFactory
	{
		public ISSSRMXRpt_VendorPackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRMXRpt_VendorPackingSlip = new Reporting.SSSRMXRpt_VendorPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXRpt_VendorPackingSlipExt = timerfactory.Create<Reporting.ISSSRMXRpt_VendorPackingSlip>(_SSSRMXRpt_VendorPackingSlip);
			
			return iSSSRMXRpt_VendorPackingSlipExt;
		}
	}
}
