//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetOrdplanFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetOrdplanFactory
	{
		public ICLM_ApsGetOrdplan Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetOrdplan = new Production.APS.CLM_ApsGetOrdplan(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetOrdplanExt = timerfactory.Create<Production.APS.ICLM_ApsGetOrdplan>(_CLM_ApsGetOrdplan);
			
			return iCLM_ApsGetOrdplanExt;
		}
	}
}
