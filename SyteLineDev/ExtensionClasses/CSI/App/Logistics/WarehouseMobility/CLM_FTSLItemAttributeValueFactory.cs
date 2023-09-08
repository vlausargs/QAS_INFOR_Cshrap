//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLItemAttributeValueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLItemAttributeValueFactory
	{
		public ICLM_FTSLItemAttributeValue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLItemAttributeValue = new Logistics.WarehouseMobility.CLM_FTSLItemAttributeValue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLItemAttributeValueExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLItemAttributeValue>(_CLM_FTSLItemAttributeValue);
			
			return iCLM_FTSLItemAttributeValueExt;
		}
	}
}
