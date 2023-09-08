//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateLCTaxDistFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_GenerateLCTaxDistFactory
	{
		public ICLM_GenerateLCTaxDist Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GenerateLCTaxDist = new Logistics.Vendor.CLM_GenerateLCTaxDist(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GenerateLCTaxDistExt = timerfactory.Create<Logistics.Vendor.ICLM_GenerateLCTaxDist>(_CLM_GenerateLCTaxDist);
			
			return iCLM_GenerateLCTaxDistExt;
		}
	}
}
