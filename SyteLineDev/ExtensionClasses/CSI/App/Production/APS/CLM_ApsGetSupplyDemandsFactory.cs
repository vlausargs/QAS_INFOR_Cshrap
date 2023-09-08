//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSupplyDemandsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSupplyDemandsFactory
	{
		public ICLM_ApsGetSupplyDemands Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetSupplyDemands = new Production.APS.CLM_ApsGetSupplyDemands(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetSupplyDemandsExt = timerfactory.Create<Production.APS.ICLM_ApsGetSupplyDemands>(_CLM_ApsGetSupplyDemands);
			
			return iCLM_ApsGetSupplyDemandsExt;
		}
	}
}
