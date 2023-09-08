//PROJECT NAME: Production
//CLASS NAME: PmfPnSizeByMatlAvailFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnSizeByMatlAvailFactory
	{
		public IPmfPnSizeByMatlAvail Create(IApplicationDB appDB)
		{
			var _PmfPnSizeByMatlAvail = new Production.ProcessManufacturing.PmfPnSizeByMatlAvail(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnSizeByMatlAvailExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnSizeByMatlAvail>(_PmfPnSizeByMatlAvail);
			
			return iPmfPnSizeByMatlAvailExt;
		}
	}
}
