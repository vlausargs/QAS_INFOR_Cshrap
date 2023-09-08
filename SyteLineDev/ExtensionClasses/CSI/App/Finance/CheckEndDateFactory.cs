//PROJECT NAME: Finance
//CLASS NAME: CheckEndDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class CheckEndDateFactory
	{
		public ICheckEndDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckEndDate = new Finance.CheckEndDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckEndDateExt = timerfactory.Create<Finance.ICheckEndDate>(_CheckEndDate);
			
			return iCheckEndDateExt;
		}
	}
}
