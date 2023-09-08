//PROJECT NAME: Logistics
//CLASS NAME: GetCoNonInvAcctFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCoNonInvAcctFactory
	{
		public IGetCoNonInvAcct Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCoNonInvAcct = new Logistics.Customer.GetCoNonInvAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCoNonInvAcctExt = timerfactory.Create<Logistics.Customer.IGetCoNonInvAcct>(_GetCoNonInvAcct);
			
			return iGetCoNonInvAcctExt;
		}
	}
}
