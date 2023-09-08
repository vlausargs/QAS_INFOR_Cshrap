//PROJECT NAME: Finance
//CLASS NAME: CCIGetTransInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.CreditCard
{
	public class CCIGetTransInfoFactory
	{
		public ICCIGetTransInfo Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CCIGetTransInfo = new Finance.CreditCard.CCIGetTransInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCCIGetTransInfoExt = timerfactory.Create<Finance.CreditCard.ICCIGetTransInfo>(_CCIGetTransInfo);
			
			return iCCIGetTransInfoExt;
		}
	}
}
