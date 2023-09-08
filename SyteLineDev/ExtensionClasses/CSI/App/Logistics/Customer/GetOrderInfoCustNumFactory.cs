//PROJECT NAME: App.Logistics.Customer
//CLASS NAME: GetOrderInfoCustNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetOrderInfoCustNumFactory
	{
		public IGetOrderInfoCustNum Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _GetOrderInfoCustNum = new Logistics.Customer.GetOrderInfoCustNum(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetOrderInfoCustNumExt = timerfactory.Create<Logistics.Customer.IGetOrderInfoCustNum>(_GetOrderInfoCustNum);

			return iGetOrderInfoCustNumExt;
		}
	}
}
