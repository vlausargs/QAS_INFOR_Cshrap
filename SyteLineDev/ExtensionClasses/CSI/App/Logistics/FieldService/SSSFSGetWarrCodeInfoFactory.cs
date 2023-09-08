//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSGetWarrCodeInFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetWarrCodeInFactory
	{
		public ISSSFSGetWarrCodeIn Create(IApplicationDB appDB)
		{
			var _SSSFSGetWarrCodeIn = new Logistics.FieldService.SSSFSGetWarrCodeIn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetWarrCodeInExt = timerfactory.Create<Logistics.FieldService.ISSSFSGetWarrCodeIn>(_SSSFSGetWarrCodeIn);
			
			return iSSSFSGetWarrCodeInExt;
		}
	}
}
