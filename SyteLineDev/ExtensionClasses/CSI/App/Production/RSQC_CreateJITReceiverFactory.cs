//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateJITReceiverFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class RSQC_CreateJITReceiverFactory
	{
		public IRSQC_CreateJITReceiver Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _RSQC_CreateJITReceiver = new Production.RSQC_CreateJITReceiver(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateJITReceiverExt = timerfactory.Create<Production.IRSQC_CreateJITReceiver>(_RSQC_CreateJITReceiver);
			
			return iRSQC_CreateJITReceiverExt;
		}
	}
}
