//PROJECT NAME: Logistics
//CLASS NAME: CreateReplenPOReleaseforItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CreateReplenPOReleaseforItemFactory
	{
		public ICreateReplenPOReleaseforItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateReplenPOReleaseforItem = new Logistics.Vendor.CreateReplenPOReleaseforItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateReplenPOReleaseforItemExt = timerfactory.Create<Logistics.Vendor.ICreateReplenPOReleaseforItem>(_CreateReplenPOReleaseforItem);
			
			return iCreateReplenPOReleaseforItemExt;
		}
	}
}
