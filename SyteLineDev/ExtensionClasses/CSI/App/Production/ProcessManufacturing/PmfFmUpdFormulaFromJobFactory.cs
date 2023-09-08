//PROJECT NAME: Production
//CLASS NAME: PmfFmUpdFormulaFromJobFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmUpdFormulaFromJobFactory
	{
		public IPmfFmUpdFormulaFromJob Create(IApplicationDB appDB)
		{
			var _PmfFmUpdFormulaFromJob = new Production.ProcessManufacturing.PmfFmUpdFormulaFromJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmUpdFormulaFromJobExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmUpdFormulaFromJob>(_PmfFmUpdFormulaFromJob);
			
			return iPmfFmUpdFormulaFromJobExt;
		}
	}
}
