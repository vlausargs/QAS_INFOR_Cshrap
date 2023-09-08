//PROJECT NAME: CSIMaterial
//CLASS NAME: ContainerDeleteFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ContainerDeleteFactory
	{
		public IContainerDelete Create(IApplicationDB appDB)
		{
			var _ContainerDelete = new Material.ContainerDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iContainerDeleteExt = timerfactory.Create<Material.IContainerDelete>(_ContainerDelete);
			
			return iContainerDeleteExt;
		}
	}
}
