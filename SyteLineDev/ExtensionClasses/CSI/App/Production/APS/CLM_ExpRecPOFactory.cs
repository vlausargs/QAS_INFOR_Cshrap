//PROJECT NAME: Production
//CLASS NAME: CLM_ExpRecPOFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ExpRecPOFactory
	{
		public ICLM_ExpRecPO Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExpRecPO = new Production.APS.CLM_ExpRecPO(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExpRecPOExt = timerfactory.Create<Production.APS.ICLM_ExpRecPO>(_CLM_ExpRecPO);
			
			return iCLM_ExpRecPOExt;
		}
	}
}
