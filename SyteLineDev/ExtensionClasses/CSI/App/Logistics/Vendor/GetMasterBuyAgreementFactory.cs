//PROJECT NAME: CSIVendor
//CLASS NAME: GetMasterBuyAgreementFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetMasterBuyAgreementFactory
	{
		public IGetMasterBuyAgreement Create(IApplicationDB appDB)
		{
			var _GetMasterBuyAgreement = new Logistics.Vendor.GetMasterBuyAgreement(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetMasterBuyAgreementExt = timerfactory.Create<Logistics.Vendor.IGetMasterBuyAgreement>(_GetMasterBuyAgreement);
			
			return iGetMasterBuyAgreementExt;
		}
	}
}
