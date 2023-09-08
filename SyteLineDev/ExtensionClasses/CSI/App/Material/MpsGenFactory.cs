//PROJECT NAME: CSIMaterial
//CLASS NAME: MpsGenFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class MpsGenFactory
	{
		public IMpsGen Create(IApplicationDB appDB)
		{
			var _MpsGen = new Material.MpsGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMpsGenExt = timerfactory.Create<Material.IMpsGen>(_MpsGen);
			
			return iMpsGenExt;
		}
	}
}
