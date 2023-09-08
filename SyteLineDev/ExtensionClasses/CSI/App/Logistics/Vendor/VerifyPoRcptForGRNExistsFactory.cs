//PROJECT NAME: Logistics
//CLASS NAME: VerifyPoRcptForGRNExistsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VerifyPoRcptForGRNExistsFactory
	{
		public IVerifyPoRcptForGRNExists Create(IApplicationDB appDB)
		{
			var _VerifyPoRcptForGRNExists = new Logistics.Vendor.VerifyPoRcptForGRNExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyPoRcptForGRNExistsExt = timerfactory.Create<Logistics.Vendor.IVerifyPoRcptForGRNExists>(_VerifyPoRcptForGRNExists);
			
			return iVerifyPoRcptForGRNExistsExt;
		}
	}
}
