//PROJECT NAME: Logistics
//CLASS NAME: CLM_PricePromotionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_PricePromotionsFactory
	{
		public ICLM_PricePromotions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PricePromotions = new Logistics.Customer.CLM_PricePromotions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PricePromotionsExt = timerfactory.Create<Logistics.Customer.ICLM_PricePromotions>(_CLM_PricePromotions);
			
			return iCLM_PricePromotionsExt;
		}
	}
}
