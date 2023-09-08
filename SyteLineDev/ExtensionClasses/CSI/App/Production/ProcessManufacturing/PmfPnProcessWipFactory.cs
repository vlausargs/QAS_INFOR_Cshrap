//PROJECT NAME: Production
//CLASS NAME: PmfPnProcessWipFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnProcessWipFactory
	{
		public IPmfPnProcessWip Create(IApplicationDB appDB)
		{
			var _PmfPnProcessWip = new Production.ProcessManufacturing.PmfPnProcessWip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnProcessWipExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnProcessWip>(_PmfPnProcessWip);
			
			return iPmfPnProcessWipExt;
		}
	}
}
