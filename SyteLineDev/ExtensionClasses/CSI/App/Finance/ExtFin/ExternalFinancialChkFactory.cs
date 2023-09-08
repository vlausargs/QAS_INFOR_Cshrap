//PROJECT NAME: Finance
//CLASS NAME: ExternalFinancialChkFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.ExtFin
{
	public class ExternalFinancialChkFactory
	{
		public IExternalFinancialChk Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ExternalFinancialChk = new Finance.ExtFin.ExternalFinancialChk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExternalFinancialChkExt = timerfactory.Create<Finance.ExtFin.IExternalFinancialChk>(_ExternalFinancialChk);
			
			return iExternalFinancialChkExt;
		}
	}
}
