//PROJECT NAME: Production
//CLASS NAME: PmfPnMatPostWrkFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnMatPostWrkFactory
	{
		public IPmfPnMatPostWrk Create(IApplicationDB appDB)
		{
			var _PmfPnMatPostWrk = new Production.ProcessManufacturing.PmfPnMatPostWrk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnMatPostWrkExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnMatPostWrk>(_PmfPnMatPostWrk);
			
			return iPmfPnMatPostWrkExt;
		}
	}
}
