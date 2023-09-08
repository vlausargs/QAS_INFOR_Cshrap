//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesSetItemCustFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesSetItemCustFactory
	{
		public IEstimateLinesSetItemCust Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _EstimateLinesSetItemCust = new Logistics.Customer.EstimateLinesSetItemCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstimateLinesSetItemCustExt = timerfactory.Create<Logistics.Customer.IEstimateLinesSetItemCust>(_EstimateLinesSetItemCust);
			
			return iEstimateLinesSetItemCustExt;
		}
	}
}
