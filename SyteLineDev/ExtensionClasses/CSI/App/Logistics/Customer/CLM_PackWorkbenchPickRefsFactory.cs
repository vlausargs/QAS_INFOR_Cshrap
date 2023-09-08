//PROJECT NAME: Logistics
//CLASS NAME: CLM_PackWorkbenchPickRefsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_PackWorkbenchPickRefsFactory
	{
		public ICLM_PackWorkbenchPickRefs Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PackWorkbenchPickRefs = new Logistics.Customer.CLM_PackWorkbenchPickRefs(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PackWorkbenchPickRefsExt = timerfactory.Create<Logistics.Customer.ICLM_PackWorkbenchPickRefs>(_CLM_PackWorkbenchPickRefs);
			
			return iCLM_PackWorkbenchPickRefsExt;
		}
	}
}
