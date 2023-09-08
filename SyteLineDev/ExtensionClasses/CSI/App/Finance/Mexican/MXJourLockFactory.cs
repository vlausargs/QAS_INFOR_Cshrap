//PROJECT NAME: CSIVATTransfer
//CLASS NAME: MXJourLockFactory.cs

using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXJourLockFactory
	{
		public IMXJourLock Create(IApplicationDB appDB)
		{
			var _MXJourLock = new Finance.Mexican.MXJourLock(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMXJourLockExt = timerfactory.Create<Finance.Mexican.IMXJourLock>(_MXJourLock);
			
			return iMXJourLockExt;
		}
	}
}
