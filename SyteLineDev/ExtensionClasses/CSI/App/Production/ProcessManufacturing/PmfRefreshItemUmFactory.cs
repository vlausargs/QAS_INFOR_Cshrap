//PROJECT NAME: Production
//CLASS NAME: PmfRefreshItemUmFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRefreshItemUmFactory
	{
		public IPmfRefreshItemUm Create(IApplicationDB appDB)
		{
			var _PmfRefreshItemUm = new Production.ProcessManufacturing.PmfRefreshItemUm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRefreshItemUmExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRefreshItemUm>(_PmfRefreshItemUm);
			
			return iPmfRefreshItemUmExt;
		}
	}
}
