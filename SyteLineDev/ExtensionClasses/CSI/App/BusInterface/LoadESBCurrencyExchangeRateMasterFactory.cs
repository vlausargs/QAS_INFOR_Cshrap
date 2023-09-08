//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBCurrencyExchangeRateMasterFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBCurrencyExchangeRateMasterFactory
	{
		public ILoadESBCurrencyExchangeRateMaster Create(IApplicationDB appDB)
		{
			var _LoadESBCurrencyExchangeRateMaster = new BusInterface.LoadESBCurrencyExchangeRateMaster(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBCurrencyExchangeRateMasterExt = timerfactory.Create<BusInterface.ILoadESBCurrencyExchangeRateMaster>(_LoadESBCurrencyExchangeRateMaster);
			
			return iLoadESBCurrencyExchangeRateMasterExt;
		}
	}
}
