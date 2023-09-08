//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetDelayDetailsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetDelayDetailsFactory
	{
		public ICLM_ApsGetDelayDetails Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetDelayDetails = new Production.APS.CLM_ApsGetDelayDetails(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetDelayDetailsExt = timerfactory.Create<Production.APS.ICLM_ApsGetDelayDetails>(_CLM_ApsGetDelayDetails);
			
			return iCLM_ApsGetDelayDetailsExt;
		}
	}
}
