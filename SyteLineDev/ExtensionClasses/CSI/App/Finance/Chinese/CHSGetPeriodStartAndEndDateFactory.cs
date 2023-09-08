//PROJECT NAME: Finance
//CLASS NAME: CHSGetPeriodStartAndEndDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.Chinese
{
	public class CHSGetPeriodStartAndEndDateFactory
	{
		public ICHSGetPeriodStartAndEndDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CHSGetPeriodStartAndEndDate = new Finance.Chinese.CHSGetPeriodStartAndEndDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSGetPeriodStartAndEndDateExt = timerfactory.Create<Finance.Chinese.ICHSGetPeriodStartAndEndDate>(_CHSGetPeriodStartAndEndDate);
			
			return iCHSGetPeriodStartAndEndDateExt;
		}
	}
}
