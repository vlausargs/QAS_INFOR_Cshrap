//PROJECT NAME: Production
//CLASS NAME: JmatlTpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JmatlTpFactory
	{
		public IJmatlTp Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _JmatlTp = new Production.JmatlTp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJmatlTpExt = timerfactory.Create<Production.IJmatlTp>(_JmatlTp);
			
			return iJmatlTpExt;
		}
	}
}
