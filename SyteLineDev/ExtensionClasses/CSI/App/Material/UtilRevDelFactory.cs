//PROJECT NAME: Material
//CLASS NAME: UtilRevDelFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class UtilRevDelFactory
	{
		public IUtilRevDel Create(IApplicationDB appDB)
		{
			var _UtilRevDel = new Material.UtilRevDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUtilRevDelExt = timerfactory.Create<Material.IUtilRevDel>(_UtilRevDel);
			
			return iUtilRevDelExt;
		}
	}
}
