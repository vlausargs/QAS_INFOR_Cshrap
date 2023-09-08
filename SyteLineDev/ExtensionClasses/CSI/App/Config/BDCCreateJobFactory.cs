//PROJECT NAME: Config
//CLASS NAME: BDCCreateJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class BDCCreateJobFactory
	{
		public IBDCCreateJob Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _BDCCreateJob = new Config.BDCCreateJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBDCCreateJobExt = timerfactory.Create<Config.IBDCCreateJob>(_BDCCreateJob);
			
			return iBDCCreateJobExt;
		}
	}
}
