//PROJECT NAME: Material
//CLASS NAME: SvallotFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class SvallotFactory
	{
		public ISvallot Create(IApplicationDB appDB)
		{
			var _Svallot = new Material.Svallot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSvallotExt = timerfactory.Create<Material.ISvallot>(_Svallot);
			
			return iSvallotExt;
		}
	}
}
