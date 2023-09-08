//PROJECT NAME: Material
//CLASS NAME: ValidateContainerItemsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ValidateContainerItemsFactory
	{
		public IValidateContainerItems Create(IApplicationDB appDB)
		{
			var _ValidateContainerItems = new Material.ValidateContainerItems(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateContainerItemsExt = timerfactory.Create<Material.IValidateContainerItems>(_ValidateContainerItems);
			
			return iValidateContainerItemsExt;
		}
	}
}
