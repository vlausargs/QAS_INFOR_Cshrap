//PROJECT NAME: Production
//CLASS NAME: CLM_ExpRecDemandFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ExpRecDemandFactory
	{
		public ICLM_ExpRecDemand Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExpRecDemand = new Production.APS.CLM_ExpRecDemand(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExpRecDemandExt = timerfactory.Create<Production.APS.ICLM_ExpRecDemand>(_CLM_ExpRecDemand);
			
			return iCLM_ExpRecDemandExt;
		}
	}
}
