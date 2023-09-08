//PROJECT NAME: CSIVendor
//CLASS NAME: GetApParmsDraftsPayableAcctFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetApParmsDraftsPayableAcctFactory
	{
		public IGetApParmsDraftsPayableAcct Create(IApplicationDB appDB)
		{
			var _GetApParmsDraftsPayableAcct = new Logistics.Vendor.GetApParmsDraftsPayableAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetApParmsDraftsPayableAcctExt = timerfactory.Create<Logistics.Vendor.IGetApParmsDraftsPayableAcct>(_GetApParmsDraftsPayableAcct);
			
			return iGetApParmsDraftsPayableAcctExt;
		}
	}
}
