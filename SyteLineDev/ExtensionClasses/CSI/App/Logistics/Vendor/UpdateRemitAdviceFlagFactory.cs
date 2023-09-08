//PROJECT NAME: Logistics
//CLASS NAME: UpdateRemitAdviceFlagFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class UpdateRemitAdviceFlagFactory
	{
		public IUpdateRemitAdviceFlag Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateRemitAdviceFlag = new Logistics.Vendor.UpdateRemitAdviceFlag(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateRemitAdviceFlagExt = timerfactory.Create<Logistics.Vendor.IUpdateRemitAdviceFlag>(_UpdateRemitAdviceFlag);
			
			return iUpdateRemitAdviceFlagExt;
		}
	}
}
