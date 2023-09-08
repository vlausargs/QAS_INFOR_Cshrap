//PROJECT NAME: Logistics
//CLASS NAME: GetNonInvItemInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetNonInvItemInfoFactory
	{
		public IGetNonInvItemInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNonInvItemInfo = new Logistics.Customer.GetNonInvItemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNonInvItemInfoExt = timerfactory.Create<Logistics.Customer.IGetNonInvItemInfo>(_GetNonInvItemInfo);
			
			return iGetNonInvItemInfoExt;
		}
	}
}
