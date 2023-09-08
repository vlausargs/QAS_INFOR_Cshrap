//PROJECT NAME: Finance
//CLASS NAME: SSSVTXEncryptPasswordWrapFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.CreditCard;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXEncryptPasswordWrapFactory
	{
		public ISSSVTXEncryptPasswordWrap Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{

            var iCreditCardUtil = new CreditCardUtilFactory().Create(appDB);
            var _SSSVTXEncryptPasswordWrap = new Finance.TaxInterface.SSSVTXEncryptPasswordWrap(appDB,iCreditCardUtil);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSVTXEncryptPasswordWrapExt = timerfactory.Create<Finance.TaxInterface.ISSSVTXEncryptPasswordWrap>(_SSSVTXEncryptPasswordWrap);
			
			return iSSSVTXEncryptPasswordWrapExt;
		}
	}
}
