//PROJECT NAME: Production
//CLASS NAME: PmfRefreshCnvFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRefreshCnvFactory
	{
		public IPmfRefreshCnv Create(IApplicationDB appDB)
		{
			var _PmfRefreshCnv = new Production.ProcessManufacturing.PmfRefreshCnv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRefreshCnvExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRefreshCnv>(_PmfRefreshCnv);
			
			return iPmfRefreshCnvExt;
		}
	}
}
