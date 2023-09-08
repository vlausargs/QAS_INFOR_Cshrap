//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetLateDemandIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetLateDemandIdFactory
	{
		public ICLM_ApsGetLateDemandId Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetLateDemandId = new Production.APS.CLM_ApsGetLateDemandId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetLateDemandIdExt = timerfactory.Create<Production.APS.ICLM_ApsGetLateDemandId>(_CLM_ApsGetLateDemandId);
			
			return iCLM_ApsGetLateDemandIdExt;
		}
	}
}
