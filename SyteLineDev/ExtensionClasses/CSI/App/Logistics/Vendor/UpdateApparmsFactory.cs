//PROJECT NAME: Logistics
//CLASS NAME: UpdateApparmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class UpdateApparmsFactory
	{
		public IUpdateApparms Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateApparms = new Logistics.Vendor.UpdateApparms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateApparmsExt = timerfactory.Create<Logistics.Vendor.IUpdateApparms>(_UpdateApparms);
			
			return iUpdateApparmsExt;
		}
	}
}
