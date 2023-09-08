//PROJECT NAME: Logistics
//CLASS NAME: ApVchPostingBGFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ApVchPostingBGFactory
	{
		public IApVchPostingBG Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApVchPostingBG = new Logistics.Vendor.ApVchPostingBG(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApVchPostingBGExt = timerfactory.Create<Logistics.Vendor.IApVchPostingBG>(_ApVchPostingBG);
			
			return iApVchPostingBGExt;
		}
	}
}
