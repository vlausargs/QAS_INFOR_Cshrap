//PROJECT NAME: Logistics
//CLASS NAME: CreatePurchaseOrderTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CreatePurchaseOrderTTFactory
	{
		public ICreatePurchaseOrderTT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreatePurchaseOrderTT = new Logistics.Vendor.CreatePurchaseOrderTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreatePurchaseOrderTTExt = timerfactory.Create<Logistics.Vendor.ICreatePurchaseOrderTT>(_CreatePurchaseOrderTT);
			
			return iCreatePurchaseOrderTTExt;
		}
	}
}
