//PROJECT NAME: Material
//CLASS NAME: UtilSetIytdFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class UtilSetIytdFactory
	{
		public IUtilSetIytd Create(IApplicationDB appDB)
		{
			var _UtilSetIytd = new Material.UtilSetIytd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUtilSetIytdExt = timerfactory.Create<Material.IUtilSetIytd>(_UtilSetIytd);
			
			return iUtilSetIytdExt;
		}
	}
}
