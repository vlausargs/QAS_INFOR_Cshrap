//PROJECT NAME: Production
//CLASS NAME: CLM_GetJobDemandIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_GetJobDemandIdFactory
	{
		public ICLM_GetJobDemandId Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetJobDemandId = new Production.CLM_GetJobDemandId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetJobDemandIdExt = timerfactory.Create<Production.ICLM_GetJobDemandId>(_CLM_GetJobDemandId);
			
			return iCLM_GetJobDemandIdExt;
		}
	}
}
