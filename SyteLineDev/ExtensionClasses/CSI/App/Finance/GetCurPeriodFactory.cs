//PROJECT NAME: Finance
//CLASS NAME: GetCurPeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetCurPeriodFactory
	{
		public IGetCurPeriod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCurPeriod = new Finance.GetCurPeriod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCurPeriodExt = timerfactory.Create<Finance.IGetCurPeriod>(_GetCurPeriod);
			
			return iGetCurPeriodExt;
		}
        public IGetCurPeriod Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _GetCurPeriod = new Finance.GetCurPeriod(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCurPeriodExt = timerfactory.Create<Finance.IGetCurPeriod>(_GetCurPeriod);

            return iGetCurPeriodExt;
        }
    }
}
