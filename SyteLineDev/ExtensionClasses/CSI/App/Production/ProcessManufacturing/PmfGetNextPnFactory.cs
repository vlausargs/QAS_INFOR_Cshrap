//PROJECT NAME: Production
//CLASS NAME: PmfGetNextPnFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetNextPnFactory
	{
		public IPmfGetNextPn Create(IApplicationDB appDB)
		{
			var _PmfGetNextPn = new Production.ProcessManufacturing.PmfGetNextPn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfGetNextPnExt = timerfactory.Create<Production.ProcessManufacturing.IPmfGetNextPn>(_PmfGetNextPn);
			
			return iPmfGetNextPnExt;
		}
	}
}
