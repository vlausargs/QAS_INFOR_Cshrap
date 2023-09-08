//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetSerialNumbersSROFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetSerialNumbersSROFactory
	{
		public ICLM_FTSLGetSerialNumbersSRO Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetSerialNumbersSRO = new Logistics.WarehouseMobility.CLM_FTSLGetSerialNumbersSRO(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetSerialNumbersSROExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetSerialNumbersSRO>(_CLM_FTSLGetSerialNumbersSRO);
			
			return iCLM_FTSLGetSerialNumbersSROExt;
		}
	}
}
