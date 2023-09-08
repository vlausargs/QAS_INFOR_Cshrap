//PROJECT NAME: Logistics
//CLASS NAME: CheckForUmDteUpdateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CheckForUmDteUpdateFactory
	{
		public ICheckForUmDteUpdate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckForUmDteUpdate = new Logistics.Vendor.CheckForUmDteUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckForUmDteUpdateExt = timerfactory.Create<Logistics.Vendor.ICheckForUmDteUpdate>(_CheckForUmDteUpdate);
			
			return iCheckForUmDteUpdateExt;
		}
	}
}
