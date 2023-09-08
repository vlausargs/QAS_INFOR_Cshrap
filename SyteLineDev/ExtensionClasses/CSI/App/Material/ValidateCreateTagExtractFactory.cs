//PROJECT NAME: Material
//CLASS NAME: ValidateCreateTagExtractFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ValidateCreateTagExtractFactory
	{
		public IValidateCreateTagExtract Create(IApplicationDB appDB)
		{
			var _ValidateCreateTagExtract = new Material.ValidateCreateTagExtract(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateCreateTagExtractExt = timerfactory.Create<Material.IValidateCreateTagExtract>(_ValidateCreateTagExtract);
			
			return iValidateCreateTagExtractExt;
		}
	}
}
