//PROJECT NAME: CSIMaterial
//CLASS NAME: PortalPriceActivationValidationFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PortalPriceActivationValidationFactory
	{
		public IPortalPriceActivationValidation Create(IApplicationDB appDB)
		{
			var _PortalPriceActivationValidation = new Material.PortalPriceActivationValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalPriceActivationValidationExt = timerfactory.Create<Material.IPortalPriceActivationValidation>(_PortalPriceActivationValidation);
			
			return iPortalPriceActivationValidationExt;
		}
	}
}
