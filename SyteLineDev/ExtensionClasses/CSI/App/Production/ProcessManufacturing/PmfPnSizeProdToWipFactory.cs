//PROJECT NAME: Production
//CLASS NAME: PmfPnSizeProdToWipFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnSizeProdToWipFactory
	{
		public IPmfPnSizeProdToWip Create(IApplicationDB appDB)
		{
			var _PmfPnSizeProdToWip = new Production.ProcessManufacturing.PmfPnSizeProdToWip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnSizeProdToWipExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnSizeProdToWip>(_PmfPnSizeProdToWip);
			
			return iPmfPnSizeProdToWipExt;
		}
	}
}
