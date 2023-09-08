//PROJECT NAME: Logistics
//CLASS NAME: GetPoDropShipDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetPoDropShipDataFactory
	{
		public IGetPoDropShipData Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetPoDropShipData = new Logistics.Vendor.GetPoDropShipData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPoDropShipDataExt = timerfactory.Create<Logistics.Vendor.IGetPoDropShipData>(_GetPoDropShipData);
			
			return iGetPoDropShipDataExt;
		}
	}
}
