//PROJECT NAME: Logistics
//CLASS NAME: LockCoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class LockCoFactory
	{
		public ILockCo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LockCo = new Logistics.Customer.LockCo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLockCoExt = timerfactory.Create<Logistics.Customer.ILockCo>(_LockCo);
			
			return iLockCoExt;
		}
	}
}
