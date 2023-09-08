//PROJECT NAME: Logistics
//CLASS NAME: InvPostingVerifyPrintFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvPostingVerifyPrintFactory
	{
		public IInvPostingVerifyPrint Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvPostingVerifyPrint = new Logistics.Customer.InvPostingVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvPostingVerifyPrintExt = timerfactory.Create<Logistics.Customer.IInvPostingVerifyPrint>(_InvPostingVerifyPrint);
			
			return iInvPostingVerifyPrintExt;
		}
	}
}
