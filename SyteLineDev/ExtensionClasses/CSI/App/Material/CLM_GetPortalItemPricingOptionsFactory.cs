//PROJECT NAME: Material
//CLASS NAME: CLM_GetPortalItemPricingOptionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_GetPortalItemPricingOptionsFactory
	{
		public ICLM_GetPortalItemPricingOptions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetPortalItemPricingOptions = new Material.CLM_GetPortalItemPricingOptions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetPortalItemPricingOptionsExt = timerfactory.Create<Material.ICLM_GetPortalItemPricingOptions>(_CLM_GetPortalItemPricingOptions);
			
			return iCLM_GetPortalItemPricingOptionsExt;
		}
	}
}
