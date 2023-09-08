//PROJECT NAME: Production
//CLASS NAME: ValidateMfgDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ValidateMfgDateFactory
	{
		public IValidateMfgDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateMfgDate = new Production.ValidateMfgDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateMfgDateExt = timerfactory.Create<Production.IValidateMfgDate>(_ValidateMfgDate);
			
			return iValidateMfgDateExt;
		}
	}
}
