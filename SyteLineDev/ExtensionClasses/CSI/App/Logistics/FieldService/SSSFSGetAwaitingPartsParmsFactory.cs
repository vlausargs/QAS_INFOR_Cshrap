//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetAwaitingPartsParmsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetAwaitingPartsParmsFactory
	{
		public ISSSFSGetAwaitingPartsParms Create(IApplicationDB appDB)
		{
			var _SSSFSGetAwaitingPartsParms = new Logistics.FieldService.SSSFSGetAwaitingPartsParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetAwaitingPartsParmsExt = timerfactory.Create<Logistics.FieldService.ISSSFSGetAwaitingPartsParms>(_SSSFSGetAwaitingPartsParms);
			
			return iSSSFSGetAwaitingPartsParmsExt;
		}
	}
}
