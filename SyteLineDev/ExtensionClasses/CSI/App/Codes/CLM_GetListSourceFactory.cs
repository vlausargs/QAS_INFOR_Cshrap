//PROJECT NAME: Codes
//CLASS NAME: CLM_GetListSourceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_GetListSourceFactory
	{
		public ICLM_GetListSource Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetListSource = new Codes.CLM_GetListSource(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetListSourceExt = timerfactory.Create<Codes.ICLM_GetListSource>(_CLM_GetListSource);
			
			return iCLM_GetListSourceExt;
		}
	}
}
