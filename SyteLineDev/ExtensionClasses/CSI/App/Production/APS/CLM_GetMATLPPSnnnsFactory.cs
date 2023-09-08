//PROJECT NAME: Production
//CLASS NAME: CLM_GetMATLPPSnnnsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_GetMATLPPSnnnsFactory
	{
		public ICLM_GetMATLPPSnnns Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetMATLPPSnnns = new Production.APS.CLM_GetMATLPPSnnns(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetMATLPPSnnnsExt = timerfactory.Create<Production.APS.ICLM_GetMATLPPSnnns>(_CLM_GetMATLPPSnnns);
			
			return iCLM_GetMATLPPSnnnsExt;
		}
	}
}
