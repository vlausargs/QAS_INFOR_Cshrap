//PROJECT NAME: Production
//CLASS NAME: PmfSpecBalanceWipFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfSpecBalanceWipFactory
	{
		public IPmfSpecBalanceWip Create(IApplicationDB appDB)
		{
			var _PmfSpecBalanceWip = new Production.ProcessManufacturing.PmfSpecBalanceWip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfSpecBalanceWipExt = timerfactory.Create<Production.ProcessManufacturing.IPmfSpecBalanceWip>(_PmfSpecBalanceWip);
			
			return iPmfSpecBalanceWipExt;
		}
	}
}
