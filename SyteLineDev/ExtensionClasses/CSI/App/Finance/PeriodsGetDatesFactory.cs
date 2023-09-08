//PROJECT NAME: Finance
//CLASS NAME: PeriodsGetDatesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class PeriodsGetDatesFactory : IPeriodsGetDatesFactory
    {
		public IPeriodsGetDates Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PeriodsGetDates = new Finance.PeriodsGetDates(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPeriodsGetDatesExt = timerfactory.Create<Finance.IPeriodsGetDates>(_PeriodsGetDates);
			
			return iPeriodsGetDatesExt;
		}

		public IPeriodsGetDates Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _PeriodsGetDates = new Finance.PeriodsGetDates(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPeriodsGetDatesExt = timerfactory.Create<Finance.IPeriodsGetDates>(_PeriodsGetDates);

			return iPeriodsGetDatesExt;
		}
	}
}
