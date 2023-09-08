//PROJECT NAME: Logistics
//CLASS NAME: InvPostingAutoDistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvPostingAutoDistFactory
	{
		public IInvPostingAutoDist Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvPostingAutoDist = new Logistics.Customer.InvPostingAutoDist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvPostingAutoDistExt = timerfactory.Create<Logistics.Customer.IInvPostingAutoDist>(_InvPostingAutoDist);
			
			return iInvPostingAutoDistExt;
		}
	}
}
