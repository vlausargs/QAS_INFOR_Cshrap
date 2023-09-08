//PROJECT NAME: Codes
//CLASS NAME: CLM_GetPortalItemPriceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_GetPortalItemPriceFactory
	{
		public ICLM_GetPortalItemPrice Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetPortalItemPrice = new Codes.CLM_GetPortalItemPrice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetPortalItemPriceExt = timerfactory.Create<Codes.ICLM_GetPortalItemPrice>(_CLM_GetPortalItemPrice);
			
			return iCLM_GetPortalItemPriceExt;
		}
	}
}
