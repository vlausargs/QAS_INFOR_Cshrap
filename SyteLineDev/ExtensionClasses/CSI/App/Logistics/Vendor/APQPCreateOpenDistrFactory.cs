//PROJECT NAME: Logistics
//CLASS NAME: APQPCreateOpenDistrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class APQPCreateOpenDistrFactory
	{
		public IAPQPCreateOpenDistr Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _APQPCreateOpenDistr = new Logistics.Vendor.APQPCreateOpenDistr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAPQPCreateOpenDistrExt = timerfactory.Create<Logistics.Vendor.IAPQPCreateOpenDistr>(_APQPCreateOpenDistr);
			
			return iAPQPCreateOpenDistrExt;
		}
	}
}
