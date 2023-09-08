//PROJECT NAME: Logistics
//CLASS NAME: GetNonInvAcctFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetNonInvAcctFactory
	{
		public IGetNonInvAcct Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNonInvAcct = new Logistics.Vendor.GetNonInvAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNonInvAcctExt = timerfactory.Create<Logistics.Vendor.IGetNonInvAcct>(_GetNonInvAcct);
			
			return iGetNonInvAcctExt;
		}
	}
}
