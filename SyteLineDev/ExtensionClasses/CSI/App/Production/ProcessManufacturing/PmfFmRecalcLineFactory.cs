//PROJECT NAME: Production
//CLASS NAME: PmfFMRecalcLineFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFMRecalcLineFactory
	{
		public IPmfFMRecalcLine Create(IApplicationDB appDB)
		{
			var _PmfFMRecalcLine = new Production.ProcessManufacturing.PmfFMRecalcLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFMRecalcLineExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFMRecalcLine>(_PmfFMRecalcLine);
			
			return iPmfFMRecalcLineExt;
		}
	}
}
