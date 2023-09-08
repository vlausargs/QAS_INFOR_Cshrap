//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInvoiceTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInvoiceTaxFactory
	{
		public ICLM_ESBInvoiceTax Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInvoiceTax = new BusInterface.CLM_ESBInvoiceTax(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInvoiceTaxExt = timerfactory.Create<BusInterface.ICLM_ESBInvoiceTax>(_CLM_ESBInvoiceTax);
			
			return iCLM_ESBInvoiceTaxExt;
		}
	}
}
