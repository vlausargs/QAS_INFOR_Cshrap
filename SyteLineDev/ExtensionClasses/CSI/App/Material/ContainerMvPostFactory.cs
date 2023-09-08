//PROJECT NAME: CSIMaterial
//CLASS NAME: ContainerMvPostFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ContainerMvPostFactory
	{
		public IContainerMvPost Create(IApplicationDB appDB)
		{
			var _ContainerMvPost = new Material.ContainerMvPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iContainerMvPostExt = timerfactory.Create<Material.IContainerMvPost>(_ContainerMvPost);
			
			return iContainerMvPostExt;
		}
	}
}
