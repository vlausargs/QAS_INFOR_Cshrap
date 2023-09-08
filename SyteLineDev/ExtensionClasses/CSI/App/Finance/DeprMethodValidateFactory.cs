//PROJECT NAME: Finance
//CLASS NAME: DeprMethodValidateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class DeprMethodValidateFactory
	{
		public IDeprMethodValidate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DeprMethodValidate = new Finance.DeprMethodValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeprMethodValidateExt = timerfactory.Create<Finance.IDeprMethodValidate>(_DeprMethodValidate);
			
			return iDeprMethodValidateExt;
		}
	}
}
