//PROJECT NAME: Logistics
//CLASS NAME: ARFinChgPostLockJournFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARFinChgPostLockJournFactory
	{
		public IARFinChgPostLockJourn Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARFinChgPostLockJourn = new Logistics.Customer.ARFinChgPostLockJourn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARFinChgPostLockJournExt = timerfactory.Create<Logistics.Customer.IARFinChgPostLockJourn>(_ARFinChgPostLockJourn);
			
			return iARFinChgPostLockJournExt;
		}
	}
}
