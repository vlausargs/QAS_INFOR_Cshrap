//PROJECT NAME: Logistics
//CLASS NAME: InvPostingBGFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvPostingBGFactory
	{
		public IInvPostingBG Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvPostingBG = new Logistics.Customer.InvPostingBG(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvPostingBGExt = timerfactory.Create<Logistics.Customer.IInvPostingBG>(_InvPostingBG);
			
			return iInvPostingBGExt;
		}
	}
}
