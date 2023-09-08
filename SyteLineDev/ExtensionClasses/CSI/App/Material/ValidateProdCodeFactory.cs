//PROJECT NAME: Material
//CLASS NAME: ValidateProdCodeFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ValidateProdCodeFactory
	{
		public IValidateProdCode Create(IApplicationDB appDB)
		{
			var _ValidateProdCode = new Material.ValidateProdCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateProdCodeExt = timerfactory.Create<Material.IValidateProdCode>(_ValidateProdCode);
			
			return iValidateProdCodeExt;
		}
	}
}
