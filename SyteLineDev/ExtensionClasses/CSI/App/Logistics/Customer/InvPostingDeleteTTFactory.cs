//PROJECT NAME: Logistics
//CLASS NAME: InvPostingDeleteTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvPostingDeleteTTFactory
	{
		public IInvPostingDeleteTT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvPostingDeleteTT = new Logistics.Customer.InvPostingDeleteTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvPostingDeleteTTExt = timerfactory.Create<Logistics.Customer.IInvPostingDeleteTT>(_InvPostingDeleteTT);
			
			return iInvPostingDeleteTTExt;
		}
	}
}
