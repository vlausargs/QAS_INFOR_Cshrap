//PROJECT NAME: Logistics
//CLASS NAME: InvPostingArinvdSnapShotFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvPostingArinvdSnapShotFactory
	{
		public IInvPostingArinvdSnapShot Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvPostingArinvdSnapShot = new Logistics.Customer.InvPostingArinvdSnapShot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvPostingArinvdSnapShotExt = timerfactory.Create<Logistics.Customer.IInvPostingArinvdSnapShot>(_InvPostingArinvdSnapShot);
			
			return iInvPostingArinvdSnapShotExt;
		}
	}
}
