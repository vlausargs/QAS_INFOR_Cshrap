//PROJECT NAME: Codes
//CLASS NAME: CLM_GetVatProceduralMarkingDefaultsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_GetVatProceduralMarkingDefaultsFactory
	{
		public ICLM_GetVatProceduralMarkingDefaults Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetVatProceduralMarkingDefaults = new Codes.CLM_GetVatProceduralMarkingDefaults(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetVatProceduralMarkingDefaultsExt = timerfactory.Create<Codes.ICLM_GetVatProceduralMarkingDefaults>(_CLM_GetVatProceduralMarkingDefaults);
			
			return iCLM_GetVatProceduralMarkingDefaultsExt;
		}
	}
}
