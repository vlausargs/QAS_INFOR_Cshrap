//PROJECT NAME: Codes
//CLASS NAME: ValidateShiftFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class ValidateShiftFactory
	{
		public IValidateShift Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateShift = new Codes.ValidateShift(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateShiftExt = timerfactory.Create<Codes.IValidateShift>(_ValidateShift);
			
			return iValidateShiftExt;
		}
	}
}
