//PROJECT NAME: Finance
//CLASS NAME: VerifyStartDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class VerifyStartDateFactory
	{
		public IVerifyStartDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VerifyStartDate = new Finance.VerifyStartDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyStartDateExt = timerfactory.Create<Finance.IVerifyStartDate>(_VerifyStartDate);
			
			return iVerifyStartDateExt;
		}
	}
}
