//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetPBOMMATLSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetPBOMMATLSFactory
	{
		public ICLM_ApsGetPBOMMATLS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetPBOMMATLS = new Production.APS.CLM_ApsGetPBOMMATLS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetPBOMMATLSExt = timerfactory.Create<Production.APS.ICLM_ApsGetPBOMMATLS>(_CLM_ApsGetPBOMMATLS);
			
			return iCLM_ApsGetPBOMMATLSExt;
		}
	}
}
