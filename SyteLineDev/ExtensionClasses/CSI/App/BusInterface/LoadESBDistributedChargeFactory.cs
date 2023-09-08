//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBDistributedChargeFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBDistributedChargeFactory
	{
		public ILoadESBDistributedCharge Create(IApplicationDB appDB)
		{
			var _LoadESBDistributedCharge = new BusInterface.LoadESBDistributedCharge(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBDistributedChargeExt = timerfactory.Create<BusInterface.ILoadESBDistributedCharge>(_LoadESBDistributedCharge);
			
			return iLoadESBDistributedChargeExt;
		}
	}
}
