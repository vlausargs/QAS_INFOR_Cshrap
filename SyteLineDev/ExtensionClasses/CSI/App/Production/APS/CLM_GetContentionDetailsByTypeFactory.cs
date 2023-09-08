//PROJECT NAME: Production
//CLASS NAME: CLM_GetContentionDetailsByTypeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_GetContentionDetailsByTypeFactory
	{
		public ICLM_GetContentionDetailsByType Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetContentionDetailsByType = new Production.APS.CLM_GetContentionDetailsByType(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetContentionDetailsByTypeExt = timerfactory.Create<Production.APS.ICLM_GetContentionDetailsByType>(_CLM_GetContentionDetailsByType);
			
			return iCLM_GetContentionDetailsByTypeExt;
		}
	}
}
