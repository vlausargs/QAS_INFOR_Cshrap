//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutiveLateOrdersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutiveLateOrdersFactory
	{
		public ICLM_ExecutiveLateOrders Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutiveLateOrders = new Finance.CLM_ExecutiveLateOrders(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutiveLateOrdersExt = timerfactory.Create<Finance.ICLM_ExecutiveLateOrders>(_CLM_ExecutiveLateOrders);
			
			return iCLM_ExecutiveLateOrdersExt;
		}
	}
}
