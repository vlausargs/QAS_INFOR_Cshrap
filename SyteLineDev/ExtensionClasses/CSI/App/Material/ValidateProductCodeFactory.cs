//PROJECT NAME: Material
//CLASS NAME: ValidateProductCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ValidateProductCodeFactory
	{
		public IValidateProductCode Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateProductCode = new Material.ValidateProductCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateProductCodeExt = timerfactory.Create<Material.IValidateProductCode>(_ValidateProductCode);
			
			return iValidateProductCodeExt;
		}
	}
}
