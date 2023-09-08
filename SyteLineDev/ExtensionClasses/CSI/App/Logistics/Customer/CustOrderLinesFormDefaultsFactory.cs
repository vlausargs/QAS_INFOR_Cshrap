//PROJECT NAME: Logistics
//CLASS NAME: CustOrderLinesFormDefaultsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustOrderLinesFormDefaultsFactory
	{
		public ICustOrderLinesFormDefaults Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustOrderLinesFormDefaults = new Logistics.Customer.CustOrderLinesFormDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustOrderLinesFormDefaultsExt = timerfactory.Create<Logistics.Customer.ICustOrderLinesFormDefaults>(_CustOrderLinesFormDefaults);
			
			return iCustOrderLinesFormDefaultsExt;
		}
	}
}
