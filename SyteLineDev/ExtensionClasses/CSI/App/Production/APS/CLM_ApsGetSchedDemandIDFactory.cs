//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSchedDemandIDFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSchedDemandIDFactory
	{
		public ICLM_ApsGetSchedDemandID Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetSchedDemandID = new Production.APS.CLM_ApsGetSchedDemandID(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetSchedDemandIDExt = timerfactory.Create<Production.APS.ICLM_ApsGetSchedDemandID>(_CLM_ApsGetSchedDemandID);
			
			return iCLM_ApsGetSchedDemandIDExt;
		}
	}
}
