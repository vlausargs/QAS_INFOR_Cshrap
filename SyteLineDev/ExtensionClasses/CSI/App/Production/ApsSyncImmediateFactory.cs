//PROJECT NAME: Production
//CLASS NAME: ApsSyncImmediateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ApsSyncImmediateFactory
	{
		public IApsSyncImmediate Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ApsSyncImmediate = new Production.ApsSyncImmediate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsSyncImmediateExt = timerfactory.Create<Production.IApsSyncImmediate>(_ApsSyncImmediate);
			
			return iApsSyncImmediateExt;
		}
	}
}
