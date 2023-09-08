//PROJECT NAME: Logistics
//CLASS NAME: InvAdjSFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvAdjSFactory
	{
		public IInvAdjS Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvAdjS = new Logistics.Customer.InvAdjS(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvAdjSExt = timerfactory.Create<Logistics.Customer.IInvAdjS>(_InvAdjS);
			
			return iInvAdjSExt;
		}
	}
}
