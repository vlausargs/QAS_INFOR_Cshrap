//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBCurrencyExchangeRateMasterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBCurrencyExchangeRateMasterFactory
	{
		public ICLM_ESBCurrencyExchangeRateMaster Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCurrencyExchangeRateMaster = new BusInterface.CLM_ESBCurrencyExchangeRateMaster(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCurrencyExchangeRateMasterExt = timerfactory.Create<BusInterface.ICLM_ESBCurrencyExchangeRateMaster>(_CLM_ESBCurrencyExchangeRateMaster);
			
			return iCLM_ESBCurrencyExchangeRateMasterExt;
		}
	}
}
