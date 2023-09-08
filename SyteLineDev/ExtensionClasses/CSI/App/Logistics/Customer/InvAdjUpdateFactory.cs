//PROJECT NAME: Logistics
//CLASS NAME: InvAdjUpdateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvAdjUpdateFactory
	{
		public IInvAdjUpdate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvAdjUpdate = new Logistics.Customer.InvAdjUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvAdjUpdateExt = timerfactory.Create<Logistics.Customer.IInvAdjUpdate>(_InvAdjUpdate);
			
			return iInvAdjUpdateExt;
		}
	}
}
