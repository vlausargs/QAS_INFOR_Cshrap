//PROJECT NAME: Logistics
//CLASS NAME: AptrxpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AptrxpFactory
	{
		public IAptrxp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Aptrxp = new Logistics.Vendor.Aptrxp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAptrxpExt = timerfactory.Create<Logistics.Vendor.IAptrxp>(_Aptrxp);
			
			return iAptrxpExt;
		}
	}
}
