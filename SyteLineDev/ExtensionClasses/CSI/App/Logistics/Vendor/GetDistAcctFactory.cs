//PROJECT NAME: Logistics
//CLASS NAME: GetDistAcctFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetDistAcctFactory
	{
		public IGetDistAcct Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetDistAcct = new Logistics.Vendor.GetDistAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDistAcctExt = timerfactory.Create<Logistics.Vendor.IGetDistAcct>(_GetDistAcct);
			
			return iGetDistAcctExt;
		}
	}
}
