//PROJECT NAME: Production
//CLASS NAME: CLM_GetJobTranPieceDimensionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_GetJobTranPieceDimensionsFactory
	{
		public ICLM_GetJobTranPieceDimensions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetJobTranPieceDimensions = new Production.CLM_GetJobTranPieceDimensions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetJobTranPieceDimensionsExt = timerfactory.Create<Production.ICLM_GetJobTranPieceDimensions>(_CLM_GetJobTranPieceDimensions);
			
			return iCLM_GetJobTranPieceDimensionsExt;
		}
	}
}
