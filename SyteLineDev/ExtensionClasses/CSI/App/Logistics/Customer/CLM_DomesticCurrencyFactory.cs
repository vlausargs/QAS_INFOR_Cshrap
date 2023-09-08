//PROJECT NAME: Logistics
//CLASS NAME: CLM_DomesticCurrencyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_DomesticCurrencyFactory
	{
		public ICLM_DomesticCurrency Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_DomesticCurrency = new Logistics.Customer.CLM_DomesticCurrency(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_DomesticCurrencyExt = timerfactory.Create<Logistics.Customer.ICLM_DomesticCurrency>(_CLM_DomesticCurrency);
			
			return iCLM_DomesticCurrencyExt;
		}
	}
}
