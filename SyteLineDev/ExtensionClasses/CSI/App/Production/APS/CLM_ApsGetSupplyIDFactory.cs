//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSupplyIDFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSupplyIDFactory
	{
		public ICLM_ApsGetSupplyID Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetSupplyID = new Production.APS.CLM_ApsGetSupplyID(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetSupplyIDExt = timerfactory.Create<Production.APS.ICLM_ApsGetSupplyID>(_CLM_ApsGetSupplyID);
			
			return iCLM_ApsGetSupplyIDExt;
		}
	}
}
