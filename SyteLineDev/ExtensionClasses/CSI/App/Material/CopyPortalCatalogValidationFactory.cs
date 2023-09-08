//PROJECT NAME: CSIMaterial
//CLASS NAME: CopyPortalCatalogValidationFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CopyPortalCatalogValidationFactory
	{
		public ICopyPortalCatalogValidation Create(IApplicationDB appDB)
		{
			var _CopyPortalCatalogValidation = new Material.CopyPortalCatalogValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyPortalCatalogValidationExt = timerfactory.Create<Material.ICopyPortalCatalogValidation>(_CopyPortalCatalogValidation);
			
			return iCopyPortalCatalogValidationExt;
		}
	}
}
