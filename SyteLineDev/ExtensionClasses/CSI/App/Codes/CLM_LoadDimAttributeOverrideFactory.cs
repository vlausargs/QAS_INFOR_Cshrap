//PROJECT NAME: Codes
//CLASS NAME: CLM_LoadDimAttributeOverrideFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_LoadDimAttributeOverrideFactory
	{
		public ICLM_LoadDimAttributeOverride Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LoadDimAttributeOverride = new Codes.CLM_LoadDimAttributeOverride(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LoadDimAttributeOverrideExt = timerfactory.Create<Codes.ICLM_LoadDimAttributeOverride>(_CLM_LoadDimAttributeOverride);
			
			return iCLM_LoadDimAttributeOverrideExt;
		}
	}
}
