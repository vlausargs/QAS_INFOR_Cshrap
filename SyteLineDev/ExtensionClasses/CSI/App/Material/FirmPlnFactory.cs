//PROJECT NAME: CSIMaterial
//CLASS NAME: FirmPlnFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class FirmPlnFactory
	{
		public IFirmPln Create(IApplicationDB appDB)
		{
			var _FirmPln = new Material.FirmPln(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFirmPlnExt = timerfactory.Create<Material.IFirmPln>(_FirmPln);
			
			return iFirmPlnExt;
		}
	}
}
