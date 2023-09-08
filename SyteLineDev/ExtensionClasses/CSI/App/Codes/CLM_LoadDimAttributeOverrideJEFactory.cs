//PROJECT NAME: Codes
//CLASS NAME: CLM_LoadDimAttributeOverrideJEFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_LoadDimAttributeOverrideJEFactory
	{
		public ICLM_LoadDimAttributeOverrideJE Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LoadDimAttributeOverrideJE = new Codes.CLM_LoadDimAttributeOverrideJE(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LoadDimAttributeOverrideJEExt = timerfactory.Create<Codes.ICLM_LoadDimAttributeOverrideJE>(_CLM_LoadDimAttributeOverrideJE);
			
			return iCLM_LoadDimAttributeOverrideJEExt;
		}
	}
}
