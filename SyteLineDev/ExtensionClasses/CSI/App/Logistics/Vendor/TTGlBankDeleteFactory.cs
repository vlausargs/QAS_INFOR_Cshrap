//PROJECT NAME: Logistics
//CLASS NAME: TTGlBankDeleteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class TTGlBankDeleteFactory
	{
		public ITTGlBankDelete Create(IApplicationDB appDB)
		{
			var _TTGlBankDelete = new Logistics.Vendor.TTGlBankDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTGlBankDeleteExt = timerfactory.Create<Logistics.Vendor.ITTGlBankDelete>(_TTGlBankDelete);
			
			return iTTGlBankDeleteExt;
		}
	}
}
