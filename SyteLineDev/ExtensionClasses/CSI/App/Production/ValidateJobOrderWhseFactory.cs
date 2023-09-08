//PROJECT NAME: Production
//CLASS NAME: ValidateJobOrderWhseFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ValidateJobOrderWhseFactory
	{
		public IValidateJobOrderWhse Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateJobOrderWhse = new Production.ValidateJobOrderWhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateJobOrderWhseExt = timerfactory.Create<Production.IValidateJobOrderWhse>(_ValidateJobOrderWhse);
			
			return iValidateJobOrderWhseExt;
		}
	}
}
