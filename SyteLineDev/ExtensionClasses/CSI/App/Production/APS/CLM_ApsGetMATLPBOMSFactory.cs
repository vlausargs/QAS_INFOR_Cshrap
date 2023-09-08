//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetMATLPBOMSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetMATLPBOMSFactory
	{
		public ICLM_ApsGetMATLPBOMS Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetMATLPBOMS = new Production.APS.CLM_ApsGetMATLPBOMS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetMATLPBOMSExt = timerfactory.Create<Production.APS.ICLM_ApsGetMATLPBOMS>(_CLM_ApsGetMATLPBOMS);
			
			return iCLM_ApsGetMATLPBOMSExt;
		}
	}
}
