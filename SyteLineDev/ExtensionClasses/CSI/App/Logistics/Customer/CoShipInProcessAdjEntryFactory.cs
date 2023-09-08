//PROJECT NAME: Logistics
//CLASS NAME: CoShipInProcessAdjEntryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoShipInProcessAdjEntryFactory
	{
		public ICoShipInProcessAdjEntry Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoShipInProcessAdjEntry = new Logistics.Customer.CoShipInProcessAdjEntry(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoShipInProcessAdjEntryExt = timerfactory.Create<Logistics.Customer.ICoShipInProcessAdjEntry>(_CoShipInProcessAdjEntry);
			
			return iCoShipInProcessAdjEntryExt;
		}
	}
}
