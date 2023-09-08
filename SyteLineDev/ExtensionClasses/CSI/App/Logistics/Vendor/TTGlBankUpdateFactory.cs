//PROJECT NAME: Logistics
//CLASS NAME: TTGlBankUpdateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class TTGlBankUpdateFactory
	{
		public ITTGlBankUpdate Create(IApplicationDB appDB)
		{
			var _TTGlBankUpdate = new Logistics.Vendor.TTGlBankUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTGlBankUpdateExt = timerfactory.Create<Logistics.Vendor.ITTGlBankUpdate>(_TTGlBankUpdate);
			
			return iTTGlBankUpdateExt;
		}
	}
}
