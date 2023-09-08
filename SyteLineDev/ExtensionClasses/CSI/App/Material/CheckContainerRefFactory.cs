//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckContainerRefFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CheckContainerRefFactory
	{
		public ICheckContainerRef Create(IApplicationDB appDB)
		{
			var _CheckContainerRef = new Material.CheckContainerRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckContainerRefExt = timerfactory.Create<Material.ICheckContainerRef>(_CheckContainerRef);
			
			return iCheckContainerRefExt;
		}
	}
}
