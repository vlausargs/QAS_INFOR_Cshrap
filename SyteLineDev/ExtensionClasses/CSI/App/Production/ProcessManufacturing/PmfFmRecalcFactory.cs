//PROJECT NAME: Production
//CLASS NAME: PmfFmRecalcFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmRecalcFactory
	{
		public IPmfFmRecalc Create(IApplicationDB appDB)
		{
			var _PmfFmRecalc = new Production.ProcessManufacturing.PmfFmRecalc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmRecalcExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmRecalc>(_PmfFmRecalc);
			
			return iPmfFmRecalcExt;
		}
	}
}
