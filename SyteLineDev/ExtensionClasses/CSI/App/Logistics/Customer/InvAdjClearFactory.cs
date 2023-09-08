//PROJECT NAME: Logistics
//CLASS NAME: InvAdjClearFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvAdjClearFactory
	{
		public IInvAdjClear Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvAdjClear = new Logistics.Customer.InvAdjClear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvAdjClearExt = timerfactory.Create<Logistics.Customer.IInvAdjClear>(_InvAdjClear);
			
			return iInvAdjClearExt;
		}
	}
}
