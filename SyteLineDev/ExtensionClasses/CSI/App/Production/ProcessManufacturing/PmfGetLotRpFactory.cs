//PROJECT NAME: Production
//CLASS NAME: PmfGetLotRpFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetLotRpFactory
	{
		public IPmfGetLotRp Create(IApplicationDB appDB)
		{
			var _PmfGetLotRp = new Production.ProcessManufacturing.PmfGetLotRp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfGetLotRpExt = timerfactory.Create<Production.ProcessManufacturing.IPmfGetLotRp>(_PmfGetLotRp);
			
			return iPmfGetLotRpExt;
		}
	}
}
