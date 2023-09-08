//PROJECT NAME: CSIMaterial
//CLASS NAME: ContainerAddFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ContainerAddFactory
	{
		public IContainerAdd Create(IApplicationDB appDB)
		{
			var _ContainerAdd = new Material.ContainerAdd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iContainerAddExt = timerfactory.Create<Material.IContainerAdd>(_ContainerAdd);
			
			return iContainerAddExt;
		}
	}
}
