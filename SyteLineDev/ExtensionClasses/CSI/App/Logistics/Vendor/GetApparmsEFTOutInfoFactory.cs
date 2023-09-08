//PROJECT NAME: CSIVendor
//CLASS NAME: GetApparmsEFTOutInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetApparmsEFTOutInfoFactory
	{
		public IGetApparmsEFTOutInfo Create(IApplicationDB appDB)
		{
			var _GetApparmsEFTOutInfo = new Logistics.Vendor.GetApparmsEFTOutInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetApparmsEFTOutInfoExt = timerfactory.Create<Logistics.Vendor.IGetApparmsEFTOutInfo>(_GetApparmsEFTOutInfo);
			
			return iGetApparmsEFTOutInfoExt;
		}
	}
}
