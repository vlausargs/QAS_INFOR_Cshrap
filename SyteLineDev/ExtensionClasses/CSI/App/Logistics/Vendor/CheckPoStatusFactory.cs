//PROJECT NAME: Logistics
//CLASS NAME: CheckPoStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CheckPoStatusFactory
	{
		public ICheckPoStatus Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckPoStatus = new Logistics.Vendor.CheckPoStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckPoStatusExt = timerfactory.Create<Logistics.Vendor.ICheckPoStatus>(_CheckPoStatus);
			
			return iCheckPoStatusExt;
		}
	}
}
