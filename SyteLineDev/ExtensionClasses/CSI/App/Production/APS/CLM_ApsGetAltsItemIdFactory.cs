//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetAltsItemIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetAltsItemIdFactory
	{
		public ICLM_ApsGetAltsItemId Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetAltsItemId = new Production.APS.CLM_ApsGetAltsItemId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetAltsItemIdExt = timerfactory.Create<Production.APS.ICLM_ApsGetAltsItemId>(_CLM_ApsGetAltsItemId);
			
			return iCLM_ApsGetAltsItemIdExt;
		}
	}
}
