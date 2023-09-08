//PROJECT NAME: Logistics
//CLASS NAME: ResvCoitemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ResvCoitemFactory
	{
		public IResvCoitem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ResvCoitem = new Logistics.Customer.ResvCoitem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iResvCoitemExt = timerfactory.Create<Logistics.Customer.IResvCoitem>(_ResvCoitem);
			
			return iResvCoitemExt;
		}
	}
}
