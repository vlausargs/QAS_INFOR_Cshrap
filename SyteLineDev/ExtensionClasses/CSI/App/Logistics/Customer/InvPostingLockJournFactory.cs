//PROJECT NAME: Logistics
//CLASS NAME: InvPostingLockJournFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvPostingLockJournFactory
	{
		public IInvPostingLockJourn Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _InvPostingLockJourn = new Logistics.Customer.InvPostingLockJourn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvPostingLockJournExt = timerfactory.Create<Logistics.Customer.IInvPostingLockJourn>(_InvPostingLockJourn);
			
			return iInvPostingLockJournExt;
		}
	}
}
