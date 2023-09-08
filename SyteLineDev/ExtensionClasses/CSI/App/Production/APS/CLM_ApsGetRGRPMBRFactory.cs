//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetRGRPMBRFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetRGRPMBRFactory
	{
		public ICLM_ApsGetRGRPMBR Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetRGRPMBR = new Production.APS.CLM_ApsGetRGRPMBR(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetRGRPMBRExt = timerfactory.Create<Production.APS.ICLM_ApsGetRGRPMBR>(_CLM_ApsGetRGRPMBR);
			
			return iCLM_ApsGetRGRPMBRExt;
		}
	}
}
