//PROJECT NAME: Logistics
//CLASS NAME: ARPayPostLockJourFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARPayPostLockJourFactory
	{
		public IARPayPostLockJour Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARPayPostLockJour = new Logistics.Customer.ARPayPostLockJour(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPayPostLockJourExt = timerfactory.Create<Logistics.Customer.IARPayPostLockJour>(_ARPayPostLockJour);
			
			return iARPayPostLockJourExt;
		}
	}
}
