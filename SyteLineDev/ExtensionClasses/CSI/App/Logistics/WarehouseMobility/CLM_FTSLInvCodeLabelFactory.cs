//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLInvCodeLabelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLInvCodeLabelFactory
	{
		public ICLM_FTSLInvCodeLabel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLInvCodeLabel = new Logistics.WarehouseMobility.CLM_FTSLInvCodeLabel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLInvCodeLabelExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLInvCodeLabel>(_CLM_FTSLInvCodeLabel);
			
			return iCLM_FTSLInvCodeLabelExt;
		}
	}
}
