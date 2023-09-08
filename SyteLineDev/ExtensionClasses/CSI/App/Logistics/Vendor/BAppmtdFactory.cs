//PROJECT NAME: Logistics
//CLASS NAME: BAppmtdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class BAppmtdFactory
	{
		public IBAppmtd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BAppmtd = new Logistics.Vendor.BAppmtd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBAppmtdExt = timerfactory.Create<Logistics.Vendor.IBAppmtd>(_BAppmtd);
			
			return iBAppmtdExt;
		}
	}
}
