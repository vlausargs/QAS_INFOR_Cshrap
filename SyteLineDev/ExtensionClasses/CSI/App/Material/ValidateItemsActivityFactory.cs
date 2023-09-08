//PROJECT NAME: Material
//CLASS NAME: ValidateItemsActivityFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ValidateItemsActivityFactory
	{
		public IValidateItemsActivity Create(IApplicationDB appDB)
		{
			var _ValidateItemsActivity = new Material.ValidateItemsActivity(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateItemsActivityExt = timerfactory.Create<Material.IValidateItemsActivity>(_ValidateItemsActivity);
			
			return iValidateItemsActivityExt;
		}
	}
}
