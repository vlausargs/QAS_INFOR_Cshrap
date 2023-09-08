//PROJECT NAME: Logistics
//CLASS NAME: ArinvCalcTaxAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArinvCalcTaxAmtFactory
	{
		public IArinvCalcTaxAmt Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ArinvCalcTaxAmt = new Logistics.Customer.ArinvCalcTaxAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArinvCalcTaxAmtExt = timerfactory.Create<Logistics.Customer.IArinvCalcTaxAmt>(_ArinvCalcTaxAmt);
			
			return iArinvCalcTaxAmtExt;
		}
	}
}
