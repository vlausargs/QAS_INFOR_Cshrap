//PROJECT NAME: Material
//CLASS NAME: RemoteLotRvallotFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class RemoteLotRvallotFactory
	{
		public IRemoteLotRvallot Create(IApplicationDB appDB)
		{
			var _RemoteLotRvallot = new Material.RemoteLotRvallot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRemoteLotRvallotExt = timerfactory.Create<Material.IRemoteLotRvallot>(_RemoteLotRvallot);
			
			return iRemoteLotRvallotExt;
		}
	}
}
