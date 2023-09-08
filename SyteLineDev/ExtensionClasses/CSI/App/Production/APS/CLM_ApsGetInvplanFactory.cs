//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetInvplanFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetInvplanFactory
	{
		public ICLM_ApsGetInvplan Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetInvplan = new Production.APS.CLM_ApsGetInvplan(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetInvplanExt = timerfactory.Create<Production.APS.ICLM_ApsGetInvplan>(_CLM_ApsGetInvplan);
			
			return iCLM_ApsGetInvplanExt;
		}
	}
}
