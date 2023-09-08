//PROJECT NAME: Logistics
//CLASS NAME: GetBankCurrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetBankCurrFactory
	{
		public IGetBankCurr Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetBankCurr = new Logistics.Vendor.GetBankCurr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetBankCurrExt = timerfactory.Create<Logistics.Vendor.IGetBankCurr>(_GetBankCurr);
			
			return iGetBankCurrExt;
		}
	}
}
