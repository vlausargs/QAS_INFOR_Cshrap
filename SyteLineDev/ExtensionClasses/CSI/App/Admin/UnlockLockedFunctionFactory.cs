//PROJECT NAME: Admin
//CLASS NAME: UnlockLockedFunctionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class UnlockLockedFunctionFactory
	{
		public IUnlockLockedFunction Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UnlockLockedFunction = new Admin.UnlockLockedFunction(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUnlockLockedFunctionExt = timerfactory.Create<Admin.IUnlockLockedFunction>(_UnlockLockedFunction);
			
			return iUnlockLockedFunctionExt;
		}
	}
}
