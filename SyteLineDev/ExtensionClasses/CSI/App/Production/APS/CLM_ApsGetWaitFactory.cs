//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetWaitFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetWaitFactory
	{
		public ICLM_ApsGetWait Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetWait = new Production.APS.CLM_ApsGetWait(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetWaitExt = timerfactory.Create<Production.APS.ICLM_ApsGetWait>(_CLM_ApsGetWait);
			
			return iCLM_ApsGetWaitExt;
		}
	}
}
