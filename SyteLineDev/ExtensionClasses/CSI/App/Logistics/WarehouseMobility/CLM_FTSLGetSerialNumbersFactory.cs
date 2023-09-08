//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetSerialNumbersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetSerialNumbersFactory
	{
		public ICLM_FTSLGetSerialNumbers Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetSerialNumbers = new Logistics.WarehouseMobility.CLM_FTSLGetSerialNumbers(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetSerialNumbersExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetSerialNumbers>(_CLM_FTSLGetSerialNumbers);
			
			return iCLM_FTSLGetSerialNumbersExt;
		}
	}
}
