//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetItemIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetItemIdFactory
	{
		public ICLM_ApsGetItemId Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetItemId = new Production.APS.CLM_ApsGetItemId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetItemIdExt = timerfactory.Create<Production.APS.ICLM_ApsGetItemId>(_CLM_ApsGetItemId);
			
			return iCLM_ApsGetItemIdExt;
		}
	}
}
