//PROJECT NAME: CSIMaterial
//CLASS NAME: CopyPortalCatalogFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CopyPortalCatalogFactory
	{
		public ICopyPortalCatalog Create(IApplicationDB appDB)
		{
			var _CopyPortalCatalog = new Material.CopyPortalCatalog(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyPortalCatalogExt = timerfactory.Create<Material.ICopyPortalCatalog>(_CopyPortalCatalog);
			
			return iCopyPortalCatalogExt;
		}
	}
}
