//PROJECT NAME: Production
//CLASS NAME: PmfRptPnFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptPnFactory
	{
		public IPmfRptPn Create(IApplicationDB appDB)
		{
			var _PmfRptPn = new Production.ProcessManufacturing.PmfRptPn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRptPnExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRptPn>(_PmfRptPn);
			
			return iPmfRptPnExt;
		}
	}
}
