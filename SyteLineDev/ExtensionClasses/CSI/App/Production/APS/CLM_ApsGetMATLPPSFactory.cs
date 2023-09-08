//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetMATLPPSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetMATLPPSFactory
	{
		public ICLM_ApsGetMATLPPS Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetMATLPPS = new Production.APS.CLM_ApsGetMATLPPS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetMATLPPSExt = timerfactory.Create<Production.APS.ICLM_ApsGetMATLPPS>(_CLM_ApsGetMATLPPS);
			
			return iCLM_ApsGetMATLPPSExt;
		}
	}
}
