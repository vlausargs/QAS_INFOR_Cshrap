//PROJECT NAME: Finance
//CLASS NAME: PrtAcctDisFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class PrtAcctDisFactory
	{
		public IPrtAcctDis Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _PrtAcctDis = new Finance.PrtAcctDis(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrtAcctDisExt = timerfactory.Create<Finance.IPrtAcctDis>(_PrtAcctDis);
			
			return iPrtAcctDisExt;
		}
	}
}
