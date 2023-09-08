//PROJECT NAME: Logistics
//CLASS NAME: CheckVendRcptStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CheckVendRcptStatusFactory
	{
		public ICheckVendRcptStatus Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckVendRcptStatus = new Logistics.Vendor.CheckVendRcptStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckVendRcptStatusExt = timerfactory.Create<Logistics.Vendor.ICheckVendRcptStatus>(_CheckVendRcptStatus);
			
			return iCheckVendRcptStatusExt;
		}
	}
}
