//PROJECT NAME: Logistics
//CLASS NAME: APVchPostingAutoDistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class APVchPostingAutoDistFactory
	{
		public IAPVchPostingAutoDist Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _APVchPostingAutoDist = new Logistics.Vendor.APVchPostingAutoDist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAPVchPostingAutoDistExt = timerfactory.Create<Logistics.Vendor.IAPVchPostingAutoDist>(_APVchPostingAutoDist);
			
			return iAPVchPostingAutoDistExt;
		}
	}
}
