//PROJECT NAME: Material
//CLASS NAME: CLM_MRPOrderActionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_MRPOrderActionFactory
	{
		public ICLM_MRPOrderAction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_MRPOrderAction = new Material.CLM_MRPOrderAction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_MRPOrderActionExt = timerfactory.Create<Material.ICLM_MRPOrderAction>(_CLM_MRPOrderAction);
			
			return iCLM_MRPOrderActionExt;
		}
	}
}
