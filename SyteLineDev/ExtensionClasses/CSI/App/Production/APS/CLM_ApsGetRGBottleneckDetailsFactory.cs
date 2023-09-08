//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetRGBottleneckDetailsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetRGBottleneckDetailsFactory
	{
		public ICLM_ApsGetRGBottleneckDetails Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetRGBottleneckDetails = new Production.APS.CLM_ApsGetRGBottleneckDetails(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetRGBottleneckDetailsExt = timerfactory.Create<Production.APS.ICLM_ApsGetRGBottleneckDetails>(_CLM_ApsGetRGBottleneckDetails);
			
			return iCLM_ApsGetRGBottleneckDetailsExt;
		}
	}
}
