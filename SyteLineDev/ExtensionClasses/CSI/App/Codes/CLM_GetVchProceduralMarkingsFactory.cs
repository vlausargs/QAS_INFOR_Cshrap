//PROJECT NAME: Codes
//CLASS NAME: CLM_GetVchProceduralMarkingsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_GetVchProceduralMarkingsFactory
	{
		public ICLM_GetVchProceduralMarkings Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetVchProceduralMarkings = new Codes.CLM_GetVchProceduralMarkings(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetVchProceduralMarkingsExt = timerfactory.Create<Codes.ICLM_GetVchProceduralMarkings>(_CLM_GetVchProceduralMarkings);
			
			return iCLM_GetVchProceduralMarkingsExt;
		}
	}
}
