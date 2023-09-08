//PROJECT NAME: Logistics
//CLASS NAME: GetVendExchRate2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetVendExchRate2Factory
	{
		public IGetVendExchRate2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetVendExchRate2 = new Logistics.Vendor.GetVendExchRate2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetVendExchRate2Ext = timerfactory.Create<Logistics.Vendor.IGetVendExchRate2>(_GetVendExchRate2);
			
			return iGetVendExchRate2Ext;
		}
	}
}
