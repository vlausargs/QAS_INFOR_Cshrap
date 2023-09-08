//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXCreatePckItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class SSSRMXCreatePckItemFactory
	{
		public ISSSRMXCreatePckItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSRMXCreatePckItem = new Logistics.Customer.SSSRMXCreatePckItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXCreatePckItemExt = timerfactory.Create<Logistics.Customer.ISSSRMXCreatePckItem>(_SSSRMXCreatePckItem);
			
			return iSSSRMXCreatePckItemExt;
		}
	}
}
