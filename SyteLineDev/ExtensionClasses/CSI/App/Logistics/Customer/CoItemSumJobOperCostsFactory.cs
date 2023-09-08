//PROJECT NAME: Logistics
//CLASS NAME: CoItemSumJobOperCostsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoItemSumJobOperCostsFactory
	{
		public ICoItemSumJobOperCosts Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CoItemSumJobOperCosts = new Logistics.Customer.CoItemSumJobOperCosts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoItemSumJobOperCostsExt = timerfactory.Create<Logistics.Customer.ICoItemSumJobOperCosts>(_CoItemSumJobOperCosts);
			
			return iCoItemSumJobOperCostsExt;
		}
	}
}
