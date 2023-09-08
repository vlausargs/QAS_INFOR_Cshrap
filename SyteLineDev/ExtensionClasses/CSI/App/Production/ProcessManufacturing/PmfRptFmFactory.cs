//PROJECT NAME: Production
//CLASS NAME: PmfRptFmFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptFmFactory
	{
		public IPmfRptFm Create(IApplicationDB appDB)
		{
			var _PmfRptFm = new Production.ProcessManufacturing.PmfRptFm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRptFmExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRptFm>(_PmfRptFm);
			
			return iPmfRptFmExt;
		}
	}
}
