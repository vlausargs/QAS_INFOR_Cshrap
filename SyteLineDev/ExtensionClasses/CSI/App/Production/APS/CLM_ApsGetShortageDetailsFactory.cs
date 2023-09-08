//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetShortageDetailsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetShortageDetailsFactory
	{
		public ICLM_ApsGetShortageDetails Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetShortageDetails = new Production.APS.CLM_ApsGetShortageDetails(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetShortageDetailsExt = timerfactory.Create<Production.APS.ICLM_ApsGetShortageDetails>(_CLM_ApsGetShortageDetails);
			
			return iCLM_ApsGetShortageDetailsExt;
		}
	}
}
