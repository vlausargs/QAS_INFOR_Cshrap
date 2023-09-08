//PROJECT NAME: CSIPmf
//CLASS NAME: PmfFmGetVerFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmGetVerFactory
	{
		public IPmfFmGetVer Create(IApplicationDB appDB)
		{
			var _PmfFmGetVer = new Production.ProcessManufacturing.PmfFmGetVer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmGetVerExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmGetVer>(_PmfFmGetVer);
			
			return iPmfFmGetVerExt;
		}
	}
}
