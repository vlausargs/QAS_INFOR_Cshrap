//PROJECT NAME: Production
//CLASS NAME: PmfPnBalanceWipFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnBalanceWipFactory
	{
		public IPmfPnBalanceWip Create(IApplicationDB appDB)
		{
			var _PmfPnBalanceWip = new Production.ProcessManufacturing.PmfPnBalanceWip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnBalanceWipExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnBalanceWip>(_PmfPnBalanceWip);
			
			return iPmfPnBalanceWipExt;
		}
	}
}
