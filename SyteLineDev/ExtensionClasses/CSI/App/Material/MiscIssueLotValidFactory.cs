//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueLotValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class MiscIssueLotValidFactory
	{
		public IMiscIssueLotValid Create(IApplicationDB appDB)
		{
			var _MiscIssueLotValid = new Material.MiscIssueLotValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMiscIssueLotValidExt = timerfactory.Create<Material.IMiscIssueLotValid>(_MiscIssueLotValid);
			
			return iMiscIssueLotValidExt;
		}
	}
}
