//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetBPOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetBPOperFactory
	{
		public ICLM_ApsGetBPOper Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetBPOper = new Production.APS.CLM_ApsGetBPOper(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetBPOperExt = timerfactory.Create<Production.APS.ICLM_ApsGetBPOper>(_CLM_ApsGetBPOper);
			
			return iCLM_ApsGetBPOperExt;
		}
	}
}
