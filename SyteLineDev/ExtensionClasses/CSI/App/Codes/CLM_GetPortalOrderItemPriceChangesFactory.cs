//PROJECT NAME: Codes
//CLASS NAME: CLM_GetPortalOrderItemPriceChangesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_GetPortalOrderItemPriceChangesFactory
	{
		public ICLM_GetPortalOrderItemPriceChanges Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetPortalOrderItemPriceChanges = new Codes.CLM_GetPortalOrderItemPriceChanges(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetPortalOrderItemPriceChangesExt = timerfactory.Create<Codes.ICLM_GetPortalOrderItemPriceChanges>(_CLM_GetPortalOrderItemPriceChanges);
			
			return iCLM_GetPortalOrderItemPriceChangesExt;
		}
	}
}
