//PROJECT NAME: Codes
//CLASS NAME: ValidateTaxRegNum1Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class ValidateTaxRegNum1Factory
	{
		public IValidateTaxRegNum1 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateTaxRegNum1 = new Codes.ValidateTaxRegNum1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateTaxRegNum1Ext = timerfactory.Create<Codes.IValidateTaxRegNum1>(_ValidateTaxRegNum1);
			
			return iValidateTaxRegNum1Ext;
		}
	}
}
