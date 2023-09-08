//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateItemWhseFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ValidateItemWhseFactory
	{
		public IValidateItemWhse Create(IApplicationDB appDB)
		{
			var _ValidateItemWhse = new Material.ValidateItemWhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateItemWhseExt = timerfactory.Create<Material.IValidateItemWhse>(_ValidateItemWhse);
			
			return iValidateItemWhseExt;
		}
	}
}
