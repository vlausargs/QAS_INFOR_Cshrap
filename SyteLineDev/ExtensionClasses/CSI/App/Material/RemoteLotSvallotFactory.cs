//PROJECT NAME: Material
//CLASS NAME: RemoteLotSvallotFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class RemoteLotSvallotFactory
	{
		public IRemoteLotSvallot Create(IApplicationDB appDB)
		{
			var _RemoteLotSvallot = new Material.RemoteLotSvallot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRemoteLotSvallotExt = timerfactory.Create<Material.IRemoteLotSvallot>(_RemoteLotSvallot);
			
			return iRemoteLotSvallotExt;
		}
	}
}
