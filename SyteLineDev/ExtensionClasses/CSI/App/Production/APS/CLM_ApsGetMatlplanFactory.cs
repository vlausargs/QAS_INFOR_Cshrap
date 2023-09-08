//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetMatlplanFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetMatlplanFactory
	{
		public ICLM_ApsGetMatlplan Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetMatlplan = new Production.APS.CLM_ApsGetMatlplan(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetMatlplanExt = timerfactory.Create<Production.APS.ICLM_ApsGetMatlplan>(_CLM_ApsGetMatlplan);
			
			return iCLM_ApsGetMatlplanExt;
		}
	}
}
