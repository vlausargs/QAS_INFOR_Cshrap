//PROJECT NAME: Production
//CLASS NAME: PmfPnAutoReceiveFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnAutoReceiveFactory
	{
		public IPmfPnAutoReceive Create(IApplicationDB appDB)
		{
			var _PmfPnAutoReceive = new Production.ProcessManufacturing.PmfPnAutoReceive(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnAutoReceiveExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnAutoReceive>(_PmfPnAutoReceive);
			
			return iPmfPnAutoReceiveExt;
		}
	}
}
