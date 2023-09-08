//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSSetAvailFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSSetAvailFactory
	{
		public ISSSSetAvail Create(IApplicationDB appDB)
		{
			var _SSSSetAvail = new Logistics.FieldService.SSSSetAvail(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSSetAvailExt = timerfactory.Create<Logistics.FieldService.ISSSSetAvail>(_SSSSetAvail);
			
			return iSSSSetAvailExt;
		}
	}
}
