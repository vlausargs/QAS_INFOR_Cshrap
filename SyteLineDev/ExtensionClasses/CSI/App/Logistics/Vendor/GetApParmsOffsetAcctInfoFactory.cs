//PROJECT NAME: CSIVendor
//CLASS NAME: GetApParmsOffsetAcctInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetApParmsOffsetAcctInfoFactory
	{
		public IGetApParmsOffsetAcctInfo Create(IApplicationDB appDB)
		{
			var _GetApParmsOffsetAcctInfo = new Logistics.Vendor.GetApParmsOffsetAcctInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetApParmsOffsetAcctInfoExt = timerfactory.Create<Logistics.Vendor.IGetApParmsOffsetAcctInfo>(_GetApParmsOffsetAcctInfo);
			
			return iGetApParmsOffsetAcctInfoExt;
		}
	}
}
