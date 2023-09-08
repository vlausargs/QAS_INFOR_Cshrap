//PROJECT NAME: CSIMaterial
//CLASS NAME: ContainerIssuePostFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ContainerIssuePostFactory
	{
		public IContainerIssuePost Create(IApplicationDB appDB)
		{
			var _ContainerIssuePost = new Material.ContainerIssuePost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iContainerIssuePostExt = timerfactory.Create<Material.IContainerIssuePost>(_ContainerIssuePost);
			
			return iContainerIssuePostExt;
		}
	}
}
