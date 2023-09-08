//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetMATLATTRFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetMATLATTRFactory
	{
		public ICLM_ApsGetMATLATTR Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetMATLATTR = new Production.APS.CLM_ApsGetMATLATTR(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetMATLATTRExt = timerfactory.Create<Production.APS.ICLM_ApsGetMATLATTR>(_CLM_ApsGetMATLATTR);
			
			return iCLM_ApsGetMATLATTRExt;
		}
	}
}
