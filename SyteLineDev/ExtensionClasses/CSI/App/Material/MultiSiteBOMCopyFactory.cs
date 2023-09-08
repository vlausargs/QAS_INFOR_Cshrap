//PROJECT NAME: CSIMaterial
//CLASS NAME: MultiSiteBOMCopyFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class MultiSiteBOMCopyFactory
	{
		public IMultiSiteBOMCopy Create(IApplicationDB appDB)
		{
			var _MultiSiteBOMCopy = new Material.MultiSiteBOMCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiSiteBOMCopyExt = timerfactory.Create<Material.IMultiSiteBOMCopy>(_MultiSiteBOMCopy);
			
			return iMultiSiteBOMCopyExt;
		}
	}
}
