//PROJECT NAME: Logistics
//CLASS NAME: WBPoRcptReturnPercentageFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class WBPoRcptReturnPercentageFactory
	{
		public IWBPoRcptReturnPercentage Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _WBPoRcptReturnPercentage = new Logistics.Vendor.WBPoRcptReturnPercentage(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWBPoRcptReturnPercentageExt = timerfactory.Create<Logistics.Vendor.IWBPoRcptReturnPercentage>(_WBPoRcptReturnPercentage);
			
			return iWBPoRcptReturnPercentageExt;
		}
	}
}
