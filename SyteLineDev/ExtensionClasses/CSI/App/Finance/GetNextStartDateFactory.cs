//PROJECT NAME: Finance
//CLASS NAME: GetNextStartDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetNextStartDateFactory
	{
		public IGetNextStartDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextStartDate = new Finance.GetNextStartDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextStartDateExt = timerfactory.Create<Finance.IGetNextStartDate>(_GetNextStartDate);
			
			return iGetNextStartDateExt;
		}
	}
}
