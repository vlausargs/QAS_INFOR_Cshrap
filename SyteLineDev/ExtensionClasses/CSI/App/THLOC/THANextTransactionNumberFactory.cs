//PROJECT NAME: THLOC
//CLASS NAME: THANextTransactionNumberFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.THLOC
{
	public class THANextTransactionNumberFactory
	{
		public ITHANextTransactionNumber Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _THANextTransactionNumber = new THLOC.THANextTransactionNumber(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHANextTransactionNumberExt = timerfactory.Create<THLOC.ITHANextTransactionNumber>(_THANextTransactionNumber);
			
			return iTHANextTransactionNumberExt;
		}
	}
}
