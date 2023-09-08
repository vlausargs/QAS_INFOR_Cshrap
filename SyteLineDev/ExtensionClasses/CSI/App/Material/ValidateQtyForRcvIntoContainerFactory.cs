//PROJECT NAME: Material
//CLASS NAME: ValidateQtyForRcvIntoContainerFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ValidateQtyForRcvIntoContainerFactory
	{
		public IValidateQtyForRcvIntoContainer Create(IApplicationDB appDB)
		{
			var _ValidateQtyForRcvIntoContainer = new Material.ValidateQtyForRcvIntoContainer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateQtyForRcvIntoContainerExt = timerfactory.Create<Material.IValidateQtyForRcvIntoContainer>(_ValidateQtyForRcvIntoContainer);
			
			return iValidateQtyForRcvIntoContainerExt;
		}
	}
}
