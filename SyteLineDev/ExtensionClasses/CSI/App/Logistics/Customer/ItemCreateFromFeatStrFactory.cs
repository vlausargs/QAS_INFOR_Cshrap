//PROJECT NAME: Logistics
//CLASS NAME: ItemCreateFromFeatStrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ItemCreateFromFeatStrFactory
	{
		public IItemCreateFromFeatStr Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemCreateFromFeatStr = new Logistics.Customer.ItemCreateFromFeatStr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemCreateFromFeatStrExt = timerfactory.Create<Logistics.Customer.IItemCreateFromFeatStr>(_ItemCreateFromFeatStr);
			
			return iItemCreateFromFeatStrExt;
		}
	}
}
