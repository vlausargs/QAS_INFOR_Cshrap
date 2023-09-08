//PROJECT NAME: Admin
//CLASS NAME: FireGenericNotifyToGCFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class FireGenericNotifyToGCFactory
	{
		public IFireGenericNotifyToGC Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _FireGenericNotifyToGC = new Admin.FireGenericNotifyToGC(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFireGenericNotifyToGCExt = timerfactory.Create<Admin.IFireGenericNotifyToGC>(_FireGenericNotifyToGC);
			
			return iFireGenericNotifyToGCExt;
		}
	}
}
