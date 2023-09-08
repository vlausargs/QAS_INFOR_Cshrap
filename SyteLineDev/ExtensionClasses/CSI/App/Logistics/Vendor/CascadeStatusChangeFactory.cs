//PROJECT NAME: Logistics
//CLASS NAME: CascadeStatusChangeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CascadeStatusChangeFactory
	{
		public ICascadeStatusChange Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CascadeStatusChange = new Logistics.Vendor.CascadeStatusChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCascadeStatusChangeExt = timerfactory.Create<Logistics.Vendor.ICascadeStatusChange>(_CascadeStatusChange);
			
			return iCascadeStatusChangeExt;
		}
	}
}
