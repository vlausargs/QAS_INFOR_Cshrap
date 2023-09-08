//PROJECT NAME: Logistics
//CLASS NAME: InvPostingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvPostingFactory
	{
		public IInvPosting Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvPosting = new Logistics.Customer.InvPosting(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvPostingExt = timerfactory.Create<Logistics.Customer.IInvPosting>(_InvPosting);
			
			return iInvPostingExt;
		}
	}
}
