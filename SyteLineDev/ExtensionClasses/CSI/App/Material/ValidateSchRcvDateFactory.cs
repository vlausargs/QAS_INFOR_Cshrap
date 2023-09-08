//PROJECT NAME: Material
//CLASS NAME: ValidateSchRcvDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ValidateSchRcvDateFactory
	{
		public IValidateSchRcvDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateSchRcvDate = new Material.ValidateSchRcvDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateSchRcvDateExt = timerfactory.Create<Material.IValidateSchRcvDate>(_ValidateSchRcvDate);
			
			return iValidateSchRcvDateExt;
		}
	}
}
