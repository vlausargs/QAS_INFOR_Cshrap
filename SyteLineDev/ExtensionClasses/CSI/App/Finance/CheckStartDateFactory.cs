//PROJECT NAME: Finance
//CLASS NAME: CheckStartDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class CheckStartDateFactory
	{
		public ICheckStartDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckStartDate = new Finance.CheckStartDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckStartDateExt = timerfactory.Create<Finance.ICheckStartDate>(_CheckStartDate);
			
			return iCheckStartDateExt;
		}
	}
}
