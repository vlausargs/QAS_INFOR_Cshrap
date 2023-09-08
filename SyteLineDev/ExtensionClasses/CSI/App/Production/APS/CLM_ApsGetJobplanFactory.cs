//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetJobplanFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetJobplanFactory
	{
		public ICLM_ApsGetJobplan Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetJobplan = new Production.APS.CLM_ApsGetJobplan(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetJobplanExt = timerfactory.Create<Production.APS.ICLM_ApsGetJobplan>(_CLM_ApsGetJobplan);
			
			return iCLM_ApsGetJobplanExt;
		}
	}
}
