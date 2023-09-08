//PROJECT NAME: Production
//CLASS NAME: JobP2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobP2Factory
	{
		public IJobP2 Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _JobP2 = new Production.JobP2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobP2Ext = timerfactory.Create<Production.IJobP2>(_JobP2);
			
			return iJobP2Ext;
		}
	}
}
