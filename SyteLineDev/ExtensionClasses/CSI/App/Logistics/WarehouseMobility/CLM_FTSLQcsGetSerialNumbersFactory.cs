//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLQcsGetSerialNumbersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLQcsGetSerialNumbersFactory
	{
		public ICLM_FTSLQcsGetSerialNumbers Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLQcsGetSerialNumbers = new Logistics.WarehouseMobility.CLM_FTSLQcsGetSerialNumbers(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLQcsGetSerialNumbersExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLQcsGetSerialNumbers>(_CLM_FTSLQcsGetSerialNumbers);
			
			return iCLM_FTSLQcsGetSerialNumbersExt;
		}
	}
}
