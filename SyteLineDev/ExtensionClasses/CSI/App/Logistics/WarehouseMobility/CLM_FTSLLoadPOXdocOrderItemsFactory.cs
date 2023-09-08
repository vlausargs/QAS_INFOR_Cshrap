//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadPOXdocOrderItemsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadPOXdocOrderItemsFactory
	{
		public ICLM_FTSLLoadPOXdocOrderItems Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLLoadPOXdocOrderItems = new Logistics.WarehouseMobility.CLM_FTSLLoadPOXdocOrderItems(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLLoadPOXdocOrderItemsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLLoadPOXdocOrderItems>(_CLM_FTSLLoadPOXdocOrderItems);
			
			return iCLM_FTSLLoadPOXdocOrderItemsExt;
		}
	}
}
