//PROJECT NAME: POS
//CLASS NAME: SSSPOSValidateCustomerDomesticFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.POS
{
	public class SSSPOSValidateCustomerDomesticFactory
	{
		public ISSSPOSValidateCustomerDomestic Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _SSSPOSValidateCustomerDomestic = new POS.SSSPOSValidateCustomerDomestic(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSValidateCustomerDomesticExt = timerfactory.Create<POS.ISSSPOSValidateCustomerDomestic>(_SSSPOSValidateCustomerDomestic);
			
			return iSSSPOSValidateCustomerDomesticExt;
		}
	}
}
