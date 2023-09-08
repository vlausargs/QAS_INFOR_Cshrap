//PROJECT NAME: Production
//CLASS NAME: PmfPopulateOhWrkFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPopulateOhWrkFactory
	{
		public IPmfPopulateOhWrk Create(IApplicationDB appDB)
		{
			var _PmfPopulateOhWrk = new Production.ProcessManufacturing.PmfPopulateOhWrk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPopulateOhWrkExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPopulateOhWrk>(_PmfPopulateOhWrk);
			
			return iPmfPopulateOhWrkExt;
		}
	}
}
