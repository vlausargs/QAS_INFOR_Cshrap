//PROJECT NAME: Production
//CLASS NAME: PSSingleReleaseJobCopyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PSSingleReleaseJobCopyFactory
	{
		public IPSSingleReleaseJobCopy Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _PSSingleReleaseJobCopy = new Production.PSSingleReleaseJobCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSSingleReleaseJobCopyExt = timerfactory.Create<Production.IPSSingleReleaseJobCopy>(_PSSingleReleaseJobCopy);
			
			return iPSSingleReleaseJobCopyExt;
		}
	}
}
