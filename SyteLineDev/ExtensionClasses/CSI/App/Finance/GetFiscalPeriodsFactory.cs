//PROJECT NAME: Finance
//CLASS NAME: GetFiscalPeriodsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetFiscalPeriodsFactory
	{
		public IGetFiscalPeriods Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetFiscalPeriods = new Finance.GetFiscalPeriods(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFiscalPeriodsExt = timerfactory.Create<Finance.IGetFiscalPeriods>(_GetFiscalPeriods);
			
			return iGetFiscalPeriodsExt;
		}

        public IGetFiscalPeriods Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _GetFiscalPeriods = new Finance.GetFiscalPeriods(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetFiscalPeriodsExt = timerfactory.Create<Finance.IGetFiscalPeriods>(_GetFiscalPeriods);

            return iGetFiscalPeriodsExt;
        }
    }
}
