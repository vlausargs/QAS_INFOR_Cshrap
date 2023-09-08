//PROJECT NAME: Logistics
//CLASS NAME: CheckForActiveBGTaskFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CheckForActiveBGTaskFactory
	{
		public ICheckForActiveBGTask Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CheckForActiveBGTask = new Logistics.Vendor.CheckForActiveBGTask(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckForActiveBGTaskExt = timerfactory.Create<Logistics.Vendor.ICheckForActiveBGTask>(_CheckForActiveBGTask);
			
			return iCheckForActiveBGTaskExt;
		}
	}
}
