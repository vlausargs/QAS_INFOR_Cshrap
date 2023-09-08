//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetORDATTRFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetORDATTRFactory
	{
		public ICLM_ApsGetORDATTR Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetORDATTR = new Production.APS.CLM_ApsGetORDATTR(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetORDATTRExt = timerfactory.Create<Production.APS.ICLM_ApsGetORDATTR>(_CLM_ApsGetORDATTR);
			
			return iCLM_ApsGetORDATTRExt;
		}
	}
}
